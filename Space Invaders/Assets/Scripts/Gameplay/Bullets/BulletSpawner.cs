using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Bullets
{
    public class BulletSpawner : Spawner<Bullet>, IWeapon
    {
        public void Fire(Vector2 position, Vector2 velocity)
        {
            var b = Spawn(position)
                //.SetActive(false)
                .SetParentPool(pool)
                .SetActive(true)
                .SetVelocity(velocity);
        }
    }
}