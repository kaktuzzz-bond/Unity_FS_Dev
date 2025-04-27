using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Health
{
    public class HealthComponent : IHealthComponent
    {
        private readonly int _maxHealth;
        private int _currentHealth;

        public HealthComponent(int maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentOutOfRangeException($"Max Health <{maxHealth}>. Error");

            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        [ShowInInspector, ReadOnly]
        public float Health => (float)_currentHealth / _maxHealth;

        [ShowInInspector, ReadOnly]
        public bool IsAlive => _currentHealth > 0;

        public bool IsDead => _currentHealth <= 0;

        public void TakeDamage(int damage)
        {
            damage = Mathf.Clamp(damage, 0, _currentHealth);
            _currentHealth -= damage;
        }

        public void Kill() => _currentHealth = 0;

        [Button]
        public void Restore() => _currentHealth = _maxHealth;
    }
}