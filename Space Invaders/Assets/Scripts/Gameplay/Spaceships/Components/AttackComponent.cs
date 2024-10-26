using Gameplay.Bullets;
using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private Bullet bulletPrefab;


        public void Attack()
        {
            // OnBulletRequired?.Invoke(firePoint);
        }
    }
}