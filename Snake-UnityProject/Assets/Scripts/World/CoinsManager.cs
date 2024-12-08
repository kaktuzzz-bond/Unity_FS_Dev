using System;
using System.Collections.Generic;
using System.Linq;
using Loop;
using Modules.Coin;
using Modules.Difficulty;
using Modules.Score;
using Modules.Snake;
using Modules.World;
using Player;
using UnityEngine;
using Zenject;

namespace World
{
    public class CoinsManager : IInitializable, IDisposable
    {
        private readonly IPlayerSpawner _playerSpawner;
        private readonly GameManager _gameManager;

        private readonly CoinCollector _coinCollector;

        private ISnake _snake;


        public CoinsManager(IPlayerSpawner playerSpawner, GameManager gameManager, CoinCollector coinCollector)
        {
            _playerSpawner = playerSpawner;

            _gameManager = gameManager;
            _coinCollector = coinCollector;
        }


        public void Initialize()
        {
            _playerSpawner.OnPlayerSpawned += OnPlayerSpawned;
            _gameManager.OnGameStarted += OnGameStarted;

            _coinCollector.OnGameWon += OnGameFinished;
        }


        private void OnPlayerSpawned(ISnake snake)
        {
            _snake = snake;
            _snake.OnMoved += OnMoved;
        }


        private void OnGameStarted()
        {
            _coinCollector.DropNewCoins();
        }


        private void OnMoved(Vector2Int headPosition)
        {
            if (_coinCollector.CollectCoins(_snake.HeadPosition, out var bones))
            {
                _snake.Expand(bones);
            }
        }


        private void OnGameFinished()
        {
            _snake.OnMoved -= OnMoved;
            _gameManager.Finish();
        }


        public void Dispose()
        {
            _playerSpawner.OnPlayerSpawned -= OnPlayerSpawned;

            _gameManager.OnGameStarted -= OnGameStarted;

            _coinCollector.OnGameWon -= OnGameFinished;
        }
    }
}