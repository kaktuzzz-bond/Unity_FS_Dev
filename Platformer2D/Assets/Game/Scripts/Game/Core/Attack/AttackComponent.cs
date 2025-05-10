using System;
using Game.Scripts.Game.Core.Health;
using UnityEngine;

namespace Game.Scripts.Game.Core.Attack
{
    [Serializable]
    public class AttackComponent : IAttackComponent
    {
        [SerializeField, Min(0)]
        private int damage = 1;
        
        public void Attack(IDamagable target)
        {
            target.TakeDamage(damage);
        }
    }
}