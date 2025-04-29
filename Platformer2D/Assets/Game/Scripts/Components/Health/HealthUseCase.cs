using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Health
{
    public class HealthUseCase : IDamagable
    {
        public event Action OnDeath;

        [ShowInInspector, ReadOnly]
        public float HealthLevel => (float)_currentHealth / _maxHealth;

        [ShowInInspector, ReadOnly]
        public bool IsAlive => _currentHealth > 0;

        private readonly int _maxHealth;
        private int _currentHealth;

        public HealthUseCase(int maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentOutOfRangeException($"Max Health <{maxHealth}>. Error");

            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            damage = Mathf.Clamp(damage, 0, _currentHealth);
            _currentHealth -= damage;
            
            if(!IsAlive) OnDeath?.Invoke();
        }

        public void Kill()
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
        }

        public void RestoreHealth()
        {
            _currentHealth = _maxHealth;
        }
    }
}