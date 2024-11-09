using System;

namespace Modules.Spaceships.Health
{
    public interface IHealthService
    {
        event Action OnHealthEmpty;
        int CurrentHealth { get; }
        void ResetHealth(int startHealth = -1);
        void TakeDamage(int damage);
    }
}