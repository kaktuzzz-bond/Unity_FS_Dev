using Modules.Spaceships.Weapon;
using UnityEngine;

namespace Gameplay.Spaceships.Weapon
{
    public class BulletWeapon:IWeaponService
    {
        private readonly Transform _firePoint;
        private readonly BulletSpawner _spawner;

        public BulletWeapon(Transform firePoint, BulletSpawner spawner)
        {
            _firePoint = firePoint;
            _spawner = spawner;
        }
        public void Attack(Vector2 direction)
        {
           var bullet = _spawner.Rent();
           bullet.SetPosition(_firePoint.position, Quaternion.identity);
           bullet.Launch(direction);
        }
    }
}