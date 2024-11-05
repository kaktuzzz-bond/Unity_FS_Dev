using Modules.Pooling;
using Modules.Pooling.Scripts;
using Modules.Pooling.Scripts.Remove;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class BulletSpawner : MonobehaviourObjectPool<Bullet>
    {
        [SerializeField] private BulletTuner bulletTuner;

        public void Fire(Vector2 position, Vector2 velocity)
        {
            var bullet = Rent(position, Quaternion.identity);
            bullet.SetVelocity(velocity);
        }

        protected override void OnCreate(Bullet item)
        {
            item.OnTargetReached += Return;
        }

        protected override void OnRent(Bullet item)
        {
            bulletTuner.Tune(item);
        }

        protected override void OnReturn(Bullet item)
        {
            item.OnTargetReached -= Return;
        }
    }
}