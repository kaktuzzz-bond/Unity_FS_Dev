using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Bullets
{
    public class BulletFactory
    {
        private readonly Bullet _prefab;
        private readonly Transform _parent;
        // private const int PoolSize = 10;
        // private const int PlayerBulletDamage = 1;
        // private const int EnemyBulletDamage = 1;

        private readonly ObjectPool<Bullet> _bulletPool;

        public BulletFactory(Bullet prefab, Transform parent, int poolSize)
        {
            _prefab = prefab;
            _parent = parent;
            _bulletPool = new ObjectPool<Bullet>(_prefab, _parent, poolSize);
        }

        // public void SpawnPlayerBullet(Vector2 position, Vector2 velocity) =>
        //     SpawnBullet(position,
        //         velocity,
        //         PlayerBulletDamage,
        //         FactoryData.Colors.PlayerBulletColor,
        //         FactoryData.Layers.PlayerBulletLayer,
        //         FactoryData.Tags.EnemyTag);
        //
        // public void SpawnEnemyBullet(Vector2 position, Vector2 velocity) =>
        //     SpawnBullet(position, velocity, EnemyBulletDamage,
        //         FactoryData.Colors.EnemyBulletColor,
        //         FactoryData.Layers.EnemyBulletLayer,
        //         FactoryData.Tags.PlayerTag);

        private void SpawnBullet(Vector2 position, Vector2 velocity,
            int damage, Color color, int layer, string targetTag)
        {
            var bullet = _bulletPool.Spawn();
            bullet
                .SetActive(false)
                .SetPosition(position)
                .SetTargetTag(targetTag)
                .SetActionOnHit(() => _bulletPool.Despawn(bullet))
                .SetActive(true)
                .SetVelocity(velocity);
        }
    }
}