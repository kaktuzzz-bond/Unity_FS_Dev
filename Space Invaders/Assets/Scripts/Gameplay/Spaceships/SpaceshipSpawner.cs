using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class SpaceshipSpawner
    {
        private readonly Spaceship _spaceshipPrefab;
        private readonly Transform _parent;
        private readonly int _health;
        private readonly float _speed;
        private readonly string _unitTag;
        private readonly int _physicsLayer;

        private readonly ObjectPool<Spaceship> _pool;

        public SpaceshipSpawner(Spaceship spaceshipPrefab, Transform parent, int health,
            float speed, string unitTag, int physicsLayer, int poolCapacity = 1)
        {
            _spaceshipPrefab = spaceshipPrefab;
            _parent = parent;
            _health = health;
            _speed = speed;
            _unitTag = unitTag;
            _physicsLayer = physicsLayer;

            _pool = new ObjectPool<Spaceship>(_spaceshipPrefab, _parent, poolCapacity);
        }

        public Spaceship Spawn(Vector2 position)
        {
            var spaceship = _pool.Spawn();

            SetupSpaceship(
                spaceship: spaceship,
                position: position,
                health: _health,
                speed: _speed,
                parent: _parent,
                unitTag: _unitTag,
                physicsLayer: _physicsLayer);

            OnSpawn();

            return spaceship;
        }

        private void OnSpawn()
        {
            //additional tuning
        }

        private void SetupSpaceship(Spaceship spaceship, Vector2 position, int health, float speed,
            Transform parent, string unitTag, int physicsLayer)
        {
            spaceship
                .SetActive(false)
                .SetPositionAndRotation(position, Quaternion.identity)
                .SetParent(parent)
                .SetTag(unitTag)
                .SetPhysicsLayer(physicsLayer)
                .SetActive(true);
        }
    }
}