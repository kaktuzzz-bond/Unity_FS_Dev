using System;

namespace Modules.Spaceships.Health
{
    public class HealthService : IHealthService
    {
        public event Action OnHealthEmpty;
        public int CurrentHealth { get; private set; }
        private readonly int _maxHealth;


        public HealthService(int maxHealth, int startHealth = -1)
        {
            if (maxHealth < 0)
                throw new ArgumentOutOfRangeException(nameof(maxHealth), maxHealth,
                    "Max health must be greater than zero.");

            _maxHealth = maxHealth;

            ResetHealth(startHealth);
        }
        
        public void ResetHealth(int startHealth = -1)
        {
            if (startHealth < 0 || startHealth > _maxHealth)
                startHealth = _maxHealth;
            CurrentHealth = startHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth > 0) return;

            CurrentHealth = 0;
            OnHealthEmpty?.Invoke();
        }
    }
}