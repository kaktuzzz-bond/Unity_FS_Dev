using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class BulletSpawner : Spawner<Bullet>, IWeapon
    {
        public void Fire(Vector2 position, Vector2 velocity)
        {
            var bullet = Spawn(position);
            bullet.SetReleaseAction(pool.Despawn);
            bullet.Activity = true;
            bullet.Velocity = velocity;
        }
    }
}