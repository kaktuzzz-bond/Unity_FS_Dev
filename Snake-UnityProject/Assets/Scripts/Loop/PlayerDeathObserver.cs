using System;
using Modules.Snake;
using Modules.World;
using UnityEngine;

namespace Loop
{
    public class PlayerDeathObserver : IDeathObserver
    {
        public event Action OnDeath;

        private readonly IWorldBounds _worldBounds;
        private ISnake _player;


        public PlayerDeathObserver(IWorldBounds worldBounds)
        {
            _worldBounds = worldBounds;
        }


        public void StartObserving(ISnake snake)
        {
            _player = snake;
            _player.OnMoved += OnPlayerMoved;
            _player.OnSelfCollided += OnSelfCollided;
        }


        private void OnPlayerMoved(Vector2Int position)
        {
            if (_worldBounds.IsInBounds(position)) return;

            OnDeath?.Invoke();

            CancelObserving();
        }


        private void OnSelfCollided()
        {
            OnDeath?.Invoke();

            CancelObserving();
        }


        public void CancelObserving()
        {
            _player.OnMoved -= OnPlayerMoved;
            _player.OnSelfCollided -= OnSelfCollided;
        }
    }
}