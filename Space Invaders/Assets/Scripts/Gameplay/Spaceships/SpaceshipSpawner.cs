using Gameplay.Weapon;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class SpaceshipSpawner : Spawner<Spaceship>
    {
        [SerializeField] private BulletSpawner bulletSpawner;


        public Spaceship Create()
        {
            var spaceship = Spawn();

            return SetupSpaceship(spaceship);
        }

        public Spaceship Create(Vector2 position)
        {
            var spaceship = Spawn(position);

            return SetupSpaceship(spaceship);
        }

        private Spaceship SetupSpaceship(Spaceship spaceship)
        {
            spaceship.SetReleaseAction(pool.Despawn);
            spaceship.SetWeapon(bulletSpawner)
                .SetActive(true);
            return spaceship;
        }
    }
}