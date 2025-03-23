using Game.Scripts.Components.Health;
using UnityEngine;

namespace Game.Scripts.Components.Attack
{
    public class AttackComponent: IAttackable
    {
        private readonly int _damage;

        public AttackComponent(int damage)
        {
            _damage = damage;
        }
        public void Attack(IDamagable target)
        {
            target.TakeDamage(_damage);
        }
    }
}