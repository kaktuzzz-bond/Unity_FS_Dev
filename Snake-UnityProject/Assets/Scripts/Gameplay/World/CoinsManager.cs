using Gameplay.Management;
using Gameplay.Player;
using Modules.Snake;
using UnityEngine;

namespace Gameplay.World
{
    public class CoinsManager : IGameStartedListener, IGameFinishedListener
    {
        private readonly IPlayerSpawner _playerSpawner;

        private readonly CoinCollector _coinCollector;

        private ISnake _snake;


        public CoinsManager(IPlayerSpawner playerSpawner, CoinCollector coinCollector)
        {
            _playerSpawner = playerSpawner;

            _coinCollector = coinCollector;
        }


        public void OnGameStarted()
        {
            _playerSpawner.OnPlayerSpawned += OnPlayerSpawned;
            _coinCollector.DropNewCoins();
        }


        private void OnPlayerSpawned(ISnake snake)
        {
            _snake = snake;
            _snake.OnMoved += OnMoved;
        }


        private void OnMoved(Vector2Int headPosition)
        {
            if (_coinCollector.CollectCoins(_snake.HeadPosition, out var bones))
            {
                _snake.Expand(bones);
            }
        }


        public void OnGameFinished()
        {
            _snake.OnMoved -= OnMoved;
            _playerSpawner.OnPlayerSpawned -= OnPlayerSpawned;
        }
    }
}