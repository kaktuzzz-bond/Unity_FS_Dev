using Modules.Pooling;
using Modules.Spaceships.Weapon;
using UnityEngine;

namespace Gameplay.Spaceships.Weapon
{
    public class BulletSpawner : PooledSpawner<Bullet>
    {
        [SerializeField] private BulletConfig config;

        protected override void OnCreate(Bullet item)
        {
            item.Initialize(config);
        }

        protected override void OnRent(Bullet item)
        {
            item.OnTargetReached += Return;
           
        }

        protected override void OnReturn(Bullet item)
        {
            item.OnTargetReached -= Return;
        }
        
    }
}