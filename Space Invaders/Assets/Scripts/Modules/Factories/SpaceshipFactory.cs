using Modules.Pooping;
using Modules.Spaceships;
using UnityEngine;

namespace Modules.Factories
{
    public class SpaceshipFactory
    {
        private readonly PlayerSpaceship playerSpaceshipPrefab;
        private readonly EnemySpaceship enemySpaceshipPrefab;
        private readonly Transform _playerParent;
        private readonly Transform _enemyParent;
        private readonly BulletFactory _bulletFactory;

        private const int PoolSize = 7;
        private const int PlayerHealth = 5;
        private const int EnemyHealth = 3;
        private const float PlayerSpeed = 5f;
        private const float EnemySpeed = 3f;
        private const float PlayerBulletSpeed = 3f;

        private ObjectPool<SpaceshipBase> _enemyPool;
        private ObjectPool<SpaceshipBase> _playerPool;
        private SpaceshipBase _player;

        public SpaceshipFactory(PlayerSpaceship playerSpaceshipPrefab, EnemySpaceship enemySpaceshipPrefab,
            Transform playerParent, Transform enemyParent,
            BulletFactory bulletFactory)
        {
            this.playerSpaceshipPrefab = playerSpaceshipPrefab;
            this.enemySpaceshipPrefab = enemySpaceshipPrefab;
            _playerParent = playerParent;
            _enemyParent = enemyParent;
            _enemyPool = new ObjectPool<SpaceshipBase>(this.enemySpaceshipPrefab, _enemyParent, PoolSize);
            _playerPool = new ObjectPool<SpaceshipBase>(this.playerSpaceshipPrefab, _playerParent, 1);
            _bulletFactory = bulletFactory;
        }


        public SpaceshipBase SpawnPlayer()
        {
            _player = SetupSpaceship(_playerPool.Spawn(), _playerParent.position, PlayerHealth, PlayerSpeed,
                _playerParent, FactoryData.Tags.PlayerTag, FactoryData.Layers.PlayerSpaceshipLayer);

            _player.OnBulletRequired +=
                (t) => _bulletFactory.SpawnPlayerBullet(t.position, t.rotation * Vector3.up * PlayerBulletSpeed);

            return _player.SetActionOnHealthEmpty(() =>
            {
                _player.OnDespawn();
                _playerPool.Despawn(_player);
            });
        }

        public SpaceshipBase SpawnEnemy(Vector2 at)
        {
            var item = SetupSpaceship(_enemyPool.Spawn(), at, EnemyHealth, EnemySpeed, _enemyParent,
                FactoryData.Tags.EnemyTag,
                FactoryData.Layers.EnemySpaceshipLayer);

            item.OnBulletRequired += (t) =>
            {
                Vector2 startPosition = t.position;
                var velocity = ((Vector2)_player.transform.position - startPosition).normalized;

                _bulletFactory.SpawnEnemyBullet(startPosition, velocity);
            };

            return item.SetActionOnHealthEmpty(() =>
            {
                item.OnDespawn();
                _enemyPool.Despawn(item);
            });
        }

        private SpaceshipBase SetupSpaceship(SpaceshipBase spaceship, Vector2 position, int health, float speed,
            Transform parent, string unitTag, int physicsLayer)
        {
            return spaceship
                .SetActive(false)
                .SetPositionAndRotation(position, Quaternion.identity)
                .SetParent(parent)
                .SetHealth(health)
                .SetSpeed(speed)
                .SetTag(unitTag)
                .SetPhysicsLayer(physicsLayer)
                .SetActive(true);
        }
    }
}