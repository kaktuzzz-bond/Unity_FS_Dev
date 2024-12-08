using System;
using Modules.Snake;

namespace Gameplay.Player
{
    public interface IPlayerSpawner
    {
        event Action<ISnake> OnPlayerSpawned;

        ISnake SpawnPlayer();

        void DespawnPlayer();
    }
}