using System;

namespace Gameplay.Player
{
    public interface IDeathObserver
    {
        event Action OnPlayerDeath;
    }
}