using System;

namespace Game.Scripts.Game.Core.Health
{
    public interface IHealthComponent : IDamagable
    {
        event Action<float> OnHealthChanged;
        event Action OnDeath;
        bool IsAlive { get; }
        
        void RestoreHealth();
    }
}