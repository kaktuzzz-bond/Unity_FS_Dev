using Gameplay.Weapon;
using Modules.Pooling;
using Modules.Pooling.Scripts;
using Modules.Pooling.Scripts.Remove;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class SpaceshipSpawner : MonobehaviourObjectPool<Spaceship>
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