using System;

namespace Modules.Spaceships.Health
{
    public interface IHealthService
    {
        event Action OnDied;
        int CurrentHealth { get; }
        void ResetHealth(int startHealth = -1);
        void TakeDamage(int damage);
    }
}