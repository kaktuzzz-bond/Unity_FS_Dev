using Gameplay.Weapon;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class SpaceshipSpawner : ObjectPool<Spaceship>
    {
        protected override void OnCreate(Spaceship item)
        {
            item.OnDied += Return;
        }

        protected override void OnReturn(Spaceship item)
        {
            item.OnDied -= Return;
        }
    }
}