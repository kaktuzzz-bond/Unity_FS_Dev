using System;

namespace Modules.Spaceships.Scripts.Components
{
    public class HealthComponent
    {
        public event Action OnDied;
        public int CurrentHealth { get; private set; }
        private readonly int _maxHealth;


        public HealthComponent(int maxHealth, int startHealth = -1)
        {
            if (maxHealth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth,
                    "Max health must be greater than zero.");

            _maxHealth = maxHealth;

            Restore(startHealth);
        }
        
        public void Restore(int startHealth = -1)
        {
            if (startHealth < 0 || startHealth > _maxHealth)
                startHealth = _maxHealth;
            CurrentHealth = startHealth;
        }

        public void ReceiveDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth > 0) return;

            CurrentHealth = 0;
            OnDied?.Invoke();
        }
    }
}