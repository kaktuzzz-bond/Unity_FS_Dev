using Gameplay;
using UnityEngine;

namespace Modules.Units
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform parent;

        private ObjectPool<Bullet> _bulletPool;

        public void Initialize(int capacity)
        {
            _bulletPool = new ObjectPool<Bullet>(prefab, parent, capacity);
        }

        public void SpawnPlayerBullet(Vector2 position, Vector2 velocity, int damage) =>
            SpawnBullet(position,
                velocity,
                damage,
                Data.Colors.PlayerBulletColor,
                Data.Layers.PlayerBulletLayer,
                Data.Tags.EnemyTag);

        public void SpawnEnemyBullet(Vector2 position, Vector2 velocity, int damage) =>
            SpawnBullet(position, velocity, damage,
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