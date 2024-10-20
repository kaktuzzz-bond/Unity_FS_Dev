using Modules.Levels;
using Modules.Units;
using UnityEngine;

namespace Gameplay
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform parent;

        [SerializeField] private LevelBounds levelBounds;

        private const int _enemyBulletLayer = 13;
        private const int _playerBulletLayer = 14;
        private const string _playerTag = "Player";
        private const string _enemyTag = "Enemy";
        private Color _enemyBulletColor = Color.red;
        private Color _playerBulletColor = Color.blue;

        private ObjectPool<Bullet> _bulletPool;
        
        public void Initialize(int capacity)
        {
            _bulletPool = new ObjectPool<Bullet>(prefab, parent, capacity);
        }

        public void SpawnPlayerBullet(Vector2 position, Vector2 velocity, int damage) => 
            SpawnBullet(position, velocity, damage, _playerBulletColor, _playerBulletLayer, _enemyTag);

        public void SpawnEnemyBullet(Vector2 position, Vector2 velocity, int damage) => 
            SpawnBullet(position, velocity, damage, _enemyBulletColor, _enemyBulletLayer, _playerTag);

        private void SpawnBullet(Vector2 position, Vector2 velocity, int damage, Color color, int layer, string targetTag)
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