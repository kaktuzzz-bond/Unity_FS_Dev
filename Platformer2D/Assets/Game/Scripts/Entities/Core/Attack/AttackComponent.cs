using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class AttackComponent : IAttackComponent
    {
        [SerializeField, Min(0)]
        private int damage = 1;
        
        public void Attack(IHealthComponent target)
        {
            target.TakeDamage(damage);
        }
    }
}