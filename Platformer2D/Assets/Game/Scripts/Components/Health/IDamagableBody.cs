using System;

namespace Game.Scripts.Components.Health
{
    public interface IDamagableBody
    {
        event Action<int> OnDamageTaken;

        void TakeDamage(int damage);
    }
}