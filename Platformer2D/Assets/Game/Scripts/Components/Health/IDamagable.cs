using System;

namespace Game.Scripts.Components.Health
{
    public interface IDamagable
    {
        event Action OnDeath;
        float HealthLevel { get; }
        bool IsAlive { get; }

        void TakeDamage(int damage);
        void Kill();
        void RestoreHealth();
    }
}