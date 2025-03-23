using Game.Scripts.Components.Health;
using UnityEngine;

namespace Game.Scripts.Components.Attack
{
    public class AttackComponent : MonoBehaviour, IAttackable
    {
        [SerializeField, Min(0)] private int damage = 1;

        public void Attack(IDamagable target)
        {
            target.TakeDamage(damage);
        }
    }
}