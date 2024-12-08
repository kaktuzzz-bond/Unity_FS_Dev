using System;
using Modules.Snake;
using UnityEditor;


namespace Player
{
    public interface IPlayerSpawner
    {
        event Action<ISnake> OnPlayerSpawned;

        ISnake SpawnPlayer();

        void DespawnPlayer();
    }
}