using System;
using Modules.Snake;


namespace Player
{
    public interface IPlayerProvider
    {
        event Action<ISnake> OnPlayerSpawned;

        ISnake SpawnPlayer();
    }
}