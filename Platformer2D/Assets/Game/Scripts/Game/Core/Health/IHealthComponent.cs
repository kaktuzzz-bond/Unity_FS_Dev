using System;

namespace Game.Scripts.Game.Core.Health
{
    public interface IHealthComponent
    {
        event Action<float> OnHealthChanged;
        event Action OnDeath;
        float HealthLevel { get; }
        bool IsAlive { get; }

        void TakeDamage(int damage);
        void Kill();
        void RestoreHealth();
    }
}