using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Spaceships;
using Gameplay.Weapon;
using Modules.Extensions;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class SpaceshipSpawner : PooledSpawner<Spaceship>
    {
        [SerializeField] private SpaceshipConfig spaceshipConfig;
        [SerializeField] private BulletSpawner bulletSpawner;
       

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