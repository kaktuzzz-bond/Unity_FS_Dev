using System;
using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Health;

namespace Game.Scripts.Enemies.Trap
{
    public class Trap : ITrap
    {
        public event Action OnDead;

        private readonly IHealthComponent _healthComponent;
        private readonly IAttackable _attackComponent;

        public Trap(IHealthComponent healthComponent, IAttackable attackComponent)
        {
            _healthComponent = healthComponent;
            _attackComponent = attackComponent;
        }


        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
            
            if (_healthComponent.IsDead) 
                OnDead?.Invoke();
        }

        public void Attack(IDamagable target) => _attackComponent.Attack(target);
    }
}