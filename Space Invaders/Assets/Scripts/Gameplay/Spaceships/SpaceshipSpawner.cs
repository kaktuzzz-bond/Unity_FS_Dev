using System;
using Gameplay.Bullets;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class SpaceshipSpawner : MonoBehaviour
    {
        [SerializeField] private Spaceship spaceshipPrefab;
        [SerializeField] private Transform spaceshipParent;
        [SerializeField] private Transform bulletParent;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField, Min(1)] private int poolSize;

        private ObjectPool<Spaceship> _pool;


        private void Awake()
        {
            _pool = new ObjectPool<Spaceship>(spaceshipPrefab, spaceshipParent, poolSize);
        }
        
        public Spaceship Spawn()
        {
            var spaceship = _pool.Spawn();

            SetupSpaceship(spaceship, spaceshipParent.position);

            return spaceship;
        }

        public Spaceship Spawn(Vector2 position)
        {
            var spaceship = _pool.Spawn();

            SetupSpaceship(spaceship, position);

            return spaceship;
        }


        private void SetupSpaceship(Spaceship spaceship, Vector2 position)
        {
            spaceship
                .SetPositionAndRotation(position, Quaternion.identity)
                .SetWeapon(bulletSpawner)
                .SetActive(true);
        }
    }
}