using UnityEngine;

namespace Z_Gameplay.Spaceships.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        //[SerializeField] private BulletSpawner weapon;
        [SerializeField] private float bulletSpeed = 3;

        private Transform _target;
      

        public void Attack()
        {
            // if (weapon == null)
            // {
            //     Debug.LogWarning("::WEAPON:: IS NOT LOADED");
            //     return;
            // }
            //
            // var velocity = GetBulletVelocity();
            // weapon.Fire(firePoint.position, velocity);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
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