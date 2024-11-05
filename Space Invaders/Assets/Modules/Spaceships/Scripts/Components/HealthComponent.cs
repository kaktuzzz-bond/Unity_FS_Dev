using System;

namespace Modules.Spaceships.Scripts.Components
{
    public class HealthComponent
    {
        public event Action OnDied;
        public int CurrentHealth { get; private set; }
        private readonly int _maxHealth;


        public HealthComponent(int maxHealth, int startHealth)
        {
            _maxHealth = maxHealth;
            CurrentHealth = startHealth;
        }

        private void Restore()
        {
            CurrentHealth = _maxHealth;
        }

        private void ReceiveDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth > 0) return;
            
            CurrentHealth = 0;
            OnDied?.Invoke();
        }
    }
}