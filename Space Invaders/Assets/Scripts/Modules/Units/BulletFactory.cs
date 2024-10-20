using Gameplay;
using UnityEngine;

namespace Modules.Units
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int poolSize = 10;
        [SerializeField] private int playerBulletDamage = 1;
        [SerializeField] private int enemyBulletDamage = 1;
        
        private ObjectPool<Bullet> _bulletPool;

        public void Initialize()
        {
            _bulletPool = new ObjectPool<Bullet>(prefab, parent, poolSize);
        }

        public void SpawnPlayerBullet(Vector2 position, Vector2 velocity) =>
            SpawnBullet(position,
                velocity,
                playerBulletDamage,
                Data.Colors.PlayerBulletColor,
                Data.Layers.PlayerBulletLayer,
                Data.Tags.EnemyTag);

        public void SpawnEnemyBullet(Vector2 position, Vector2 velocity) =>
            SpawnBullet(position, velocity, enemyBulletDamage,
                Data.Colors.EnemyBulletColor,
                Data.Layers.EnemyBulletLayer,
                Data.Tags.PlayerTag);

        private void SpawnBullet(Vector2 position, Vector2 velocity,
            int damage, Color color, int layer, string targetTag)
        {
            var bullet = _bulletPool.Spawn();
            bullet
                .Deactivate()
                .SetPosition(position)
                .SetDamage(damage)
                .SetTargetTag(targetTag)
                .SetColor(color)
                .SetPhysicsLayer(layer)
                .SetActionOnHit(() => _bulletPool.Despawn(bullet))
                .Activate()
                .SetVelocity(velocity);
        }
    }
}