using System;
using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class HealthComponent
    {
        public event Action OnHealthEmpty;
        private readonly int _maxHealth;
        private readonly int _startHealth;

        private int _health;

        public HealthComponent(int maxHealth, int startHealth)
        {
            _maxHealth = maxHealth;
            _startHealth = startHealth;
        }

        public void ResetHealth() => 
            SetHealth(_startHealth);


        public void TakeDamage(int damage)
        {
            SetHealth(_health - damage);

            if (_health == 0)
                OnHealthEmpty?.Invoke();
        }

        private void SetHealth(int health)
        {
            _health = Mathf.Clamp(health, 0, _maxHealth);
        }
    }
}