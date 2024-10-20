using Modules.Enemies;
using Modules.Units;
using UnityEngine;

namespace Gameplay
{
    public class SpaceshipFactory : MonoBehaviour
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Transform playerParent;
        [SerializeField] private Transform enemyParent;

        [SerializeField] private int poolSize = 7;
        [SerializeField] private int playerHealth = 5;
        [SerializeField] private int enemyHealth = 3;
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private float enemySpeed = 3f;

        private ObjectPool<SpaceshipBase> _enemyPool;
        private ObjectPool<SpaceshipBase> _playerPool;
        private BulletFactory _bulletFactory;

        public void Initialize(BulletFactory bulletFactory)
        {
            _enemyPool = new ObjectPool<SpaceshipBase>(enemyPrefab, enemyParent, poolSize);
            _playerPool = new ObjectPool<SpaceshipBase>(playerPrefab, playerParent, 1);
            _bulletFactory = bulletFactory;
        }

        public SpaceshipBase SpawnPlayer()
        {
            var item = SetupSpaceship(_playerPool.Spawn(), playerParent.position, playerHealth, playerSpeed,
                playerParent,
                Data.Tags.PlayerTag, Data.Layers.PlayerSpaceshipLayer);
            return item.SetActionOnHealthEmpty(() => _playerPool.Despawn(item));
        }

        public SpaceshipBase SpawnEnemy(Vector2 at)
        {
            var item = SetupSpaceship(_enemyPool.Spawn(), at, enemyHealth, enemySpeed, enemyParent, Data.Tags.EnemyTag,
                Data.Layers.EnemySpaceshipLayer);
            return item.SetActionOnHealthEmpty(() => _enemyPool.Despawn(item));
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
                .SetBulletFactory(_bulletFactory)
                .SetPhysicsLayer(physicsLayer)
                .SetActive(true);
        }
    }
}