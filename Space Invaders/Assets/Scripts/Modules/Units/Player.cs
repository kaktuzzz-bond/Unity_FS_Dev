using Modules.Enemies;
using UnityEngine;

namespace Modules.Units
{
    public sealed class Player : SpaceshipBase
    {
        public override void Attack()
        {
            bulletFactory.SpawnPlayerBullet(firePoint.position, firePoint.rotation * Vector3.up * 3);
        }
    }
}