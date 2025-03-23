using System;
using Game.Scripts.Components.Health;

namespace Game.Scripts.Player
{
    public interface IPlayer : IDamagable
    {
        event Action<float> OnHealthChanged;
    }
}