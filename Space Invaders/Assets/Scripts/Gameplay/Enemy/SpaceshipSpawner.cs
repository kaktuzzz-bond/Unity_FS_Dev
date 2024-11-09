using Gameplay.Spaceships;
using Gameplay.Weapon;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class SpaceshipSpawner : PooledSpawner<Spaceship>
    {
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private SpaceshipConfig spaceshipConfig;

        protected override void OnCreate(Spaceship item)
        {
            item.Construct(spaceshipConfig, bulletSpawner);
        }

        protected override void OnRent(Spaceship item)
        {
            item.OnActivate();
        }

        protected override void OnReturn(Spaceship item)
        {
            item.OnDeactivate();
        }
    }
}