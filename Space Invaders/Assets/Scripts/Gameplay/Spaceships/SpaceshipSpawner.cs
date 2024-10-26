using Gameplay.Bullets;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class SpaceshipSpawner : Spawner<Spaceship>
    {
        [SerializeField] private BulletSpawner bulletSpawner;


        public Spaceship Create() =>
            Spawn()
                .SetWeapon(bulletSpawner)
                .SetActive(true);

        public Spaceship Create(Vector2 position) =>
            Spawn(position)
                .SetWeapon(bulletSpawner)
                .SetActive(true);
    }
}