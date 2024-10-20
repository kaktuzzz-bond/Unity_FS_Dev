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

        [SerializeField] private int playerHealth = 5;
        [SerializeField] private int enemyHealth = 3;
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private float enemySpeed = 3f;

        private ObjectPool<SpaceshipBase> _enemyPool;
        private ObjectPool<SpaceshipBase> _playerPool;
        private BulletFactory _bulletFactory;

        public void Initialize(int enemyPoolCapacity, BulletFactory bulletFactory)
        {
            _enemyPool = new ObjectPool<SpaceshipBase>(enemyPrefab, enemyParent, enemyPoolCapacity);
            _playerPool = new ObjectPool<SpaceshipBase>(playerPrefab, playerParent, 1);
            _bulletFactory = bulletFactory;
        }

        public SpaceshipBase SpawnPlayer() =>
            SetupSpaceship(_playerPool.Spawn(), playerParent.position, playerHealth, playerSpeed, playerParent,
                Data.Tags.PlayerTag, Data.Layers.PlayerSpaceshipLayer);

        public SpaceshipBase SpawnEnemy(Vector2 at) =>
            SetupSpaceship(_enemyPool.Spawn(), at, enemyHealth, enemySpeed, enemyParent, Data.Tags.EnemyTag,
                Data.Layers.EnemySpaceshipLayer);

        public SpaceshipBase SpawnEnemy() =>
            SetupSpaceship(_enemyPool.Spawn(), Vector2.zero, enemyHealth, enemySpeed, enemyParent, Data.Tags.EnemyTag,
                Data.Layers.EnemySpaceshipLayer);

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