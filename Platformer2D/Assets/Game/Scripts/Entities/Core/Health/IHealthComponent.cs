using System;

namespace Game.Entities
{
    public interface IHealthComponent : IDamagable
    {
        event Action<float> OnHealthChanged;
        event Action OnDeath;
        bool IsAlive { get; }
        
        void RestoreHealth();
    }
}