using Gameplay.Bullets;
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
            spaceship.SetReleaseAction(pool.Despawn);
            spaceship.SetWeapon(bulletSpawner)
                .SetActive(true);
            
            return spaceship;
        }

        public Spaceship Create(Vector2 position)
        {
            var spaceship = Spawn(position);
            spaceship.SetReleaseAction(pool.Despawn);
            spaceship.SetWeapon(bulletSpawner)
                .SetActive(true);
            
            return spaceship;
        }
    }
}