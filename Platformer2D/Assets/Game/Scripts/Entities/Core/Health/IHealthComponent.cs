using System;

namespace Game.Entities
{
    public interface IHealthComponent
    {
        event Action<float> OnHealthChanged;
        event Action OnDeath;
        bool IsAlive { get; }
        
        void RestoreHealth();
        
        void TakeDamage(int damage);
    }
}