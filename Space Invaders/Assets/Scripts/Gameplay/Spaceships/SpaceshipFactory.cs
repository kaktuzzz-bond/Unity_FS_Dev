namespace Gameplay.Spaceships
{
    public class SpaceshipFactory
    {
        // private readonly SpaceshipSpawner _playerSpawner;
        // private readonly SpaceshipSpawner _enemySpawner;
        //
        //
        // public SpaceshipFactory(PlayerSpaceship playerSpaceshipPrefab, EnemySpaceship enemySpaceshipPrefab,
        //     Transform playerParent, Transform enemyParent,
        //     BulletFactory bulletFactory)
        // {
        //     _playerSpawner = new SpaceshipSpawner(playerSpaceshipPrefab, playerParent, 5, 5f,
        //         FactoryData.Tags.PlayerTag, FactoryData.Layers.PlayerSpaceshipLayer);
        //
        //     _enemySpawner = new SpaceshipSpawner(enemySpaceshipPrefab, enemyParent, 3, 3f,
        //         FactoryData.Tags.EnemyTag, FactoryData.Layers.EnemySpaceshipLayer);
        //     
        // }
        //
        //
        // public Spaceship SpawnPlayer()
        // {
        //     _player = SetupSpaceship(_playerPool.Spawn(), _playerParent.position, PlayerHealth, PlayerSpeed,
        //         _playerParent, FactoryData.Tags.PlayerTag, FactoryData.Layers.PlayerSpaceshipLayer);
        //
        //     _player.OnBulletRequired +=
        //         (t) => _bulletFactory.SpawnPlayerBullet(t.position, t.rotation * Vector3.up * PlayerBulletSpeed);
        //
        //     return _player.SetActionOnHealthEmpty(() =>
        //     {
        //         _player.OnDespawn();
        //         _playerPool.Despawn(_player);
        //     });
        // }
        //
        // public Spaceship SpawnEnemy(Vector2 at)
        // {
        //     var item = SetupSpaceship(_enemyPool.Spawn(), at, EnemyHealth, EnemySpeed, _enemyParent,
        //         FactoryData.Tags.EnemyTag,
        //         FactoryData.Layers.EnemySpaceshipLayer);
        //
        //     item.OnBulletRequired += (t) =>
        //     {
        //         Vector2 startPosition = t.position;
        //         var velocity = ((Vector2)_player.transform.position - startPosition).normalized;
        //
        //         _bulletFactory.SpawnEnemyBullet(startPosition, velocity);
        //     };
        //
        //     return item.SetActionOnHealthEmpty(() =>
        //     {
        //         item.OnDespawn();
        //         _enemyPool.Despawn(item);
        //     });
        // }
        //
        // private Spaceship SetupSpaceship(Spaceship spaceship, Vector2 position, int health, float speed,
        //     Transform parent, string unitTag, int physicsLayer)
        // {
        //     return spaceship
        //         .SetActive(false)
        //         .SetPositionAndRotation(position, Quaternion.identity)
        //         .SetParent(parent)
        //         .SetHealth(health)
        //         .SetSpeed(speed)
        //         .SetTag(unitTag)
        //         .SetPhysicsLayer(physicsLayer)
        //         .SetActive(true);
        // }
    }
}