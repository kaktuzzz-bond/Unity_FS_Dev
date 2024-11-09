using Gameplay.Weapon;
using UnityEngine;

namespace Gameplay.Spaceships.Strategy
{
    public class AttackStrategy : IAIStrategy
    {
        private readonly Transform _firePoint;
        private readonly BulletSpawner _spawner;

        public AttackStrategy(Transform firePoint, BulletSpawner spawner)
        {
            _firePoint = firePoint;
            _spawner = spawner;
        }


        public void Update(Vector2 direction)
        {
            var bullet = _spawner.Rent();
            bullet.SetPosition(_firePoint.position, Quaternion.identity);
            bullet.Launch(direction);
        }
    }
}