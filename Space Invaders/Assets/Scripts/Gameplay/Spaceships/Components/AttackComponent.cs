using Gameplay.Weapon;
using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private float bulletSpeed = 3;

        private Transform _target;
        private IWeapon _weapon;

        public void Attack()
        {
            if (_weapon == null)
            {
                Debug.LogWarning("::WEAPON:: IS NOT LOADED");
                return;
            }

            var velocity = GetBulletVelocity();
            _weapon.Fire(firePoint.position, velocity);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        private Vector2 GetBulletVelocity()
        {
            if (_target == null)
            {
                return firePoint.rotation * Vector3.up * bulletSpeed;
            }

            Vector2 startPosition = firePoint.position;
            return ((Vector2)_target.transform.position - startPosition).normalized;
        }
    }
}