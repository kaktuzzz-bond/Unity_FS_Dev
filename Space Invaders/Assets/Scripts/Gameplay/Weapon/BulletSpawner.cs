using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Weapon
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