using System;
using Modules.Snake;
using Modules.World;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerDeathObserver : IDeathObserver, IDisposable
    {
        public event Action OnPlayerDeath;

        private readonly IPlayerSpawner _playerSpawner;
        private readonly IWorldBounds _worldBounds;
        private ISnake _player;


        public PlayerDeathObserver(IPlayerSpawner playerSpawner, IWorldBounds worldBounds)
        {
            _playerSpawner = playerSpawner;
            _worldBounds = worldBounds;

            _playerSpawner.OnPlayerSpawned += StartObserving;
        }


        private void StartObserving(ISnake snake)
        {
            _player = snake;
            _player.OnMoved += OnPlayerMoved;
            _player.OnSelfCollided += OnSelfCollided;
        }


        private void OnPlayerMoved(Vector2Int position)
        {
            if (_worldBounds.IsInBounds(position)) return;

            OnPlayerDeath?.Invoke();

            CancelObserving();
        }


        private void OnSelfCollided()
        {
            OnPlayerDeath?.Invoke();

            CancelObserving();
        }


        public void CancelObserving()
        {
            _player.OnMoved -= OnPlayerMoved;
            _player.OnSelfCollided -= OnSelfCollided;
        }


        public void Dispose()
        {
            CancelObserving();
            _playerSpawner.OnPlayerSpawned -= StartObserving;
        }
    }
}