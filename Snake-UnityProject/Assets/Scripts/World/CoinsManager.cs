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
        private readonly CoinSpawner _coinSpawner;
        private readonly WorldBounds _worldBounds;
        private readonly GameLoop _gameLoop;
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;

        private ISnake _snake;

        private readonly HashSet<Coin> _coins = new();


        public CoinsManager(IPlayerSpawner playerSpawner,
                            CoinSpawner coinSpawner,
                            WorldBounds worldBounds,
                            GameLoop gameLoop,
                            IDifficulty difficulty,
                            IScore score)
        {
            _playerSpawner = playerSpawner;
            _coinSpawner = coinSpawner;
            _worldBounds = worldBounds;
            _gameLoop = gameLoop;
            _difficulty = difficulty;
            _score = score;
        }


        public void Initialize()
        {
            _playerSpawner.OnPlayerSpawned += OnPlayerSpawned;

            _gameLoop.OnGameStarted += OnGameStarted;
            _gameLoop.OnGameFinished += OnGameFinished;
        }


        private void OnPlayerSpawned(ISnake snake)
        {
            _snake = snake;
            _snake.OnMoved += OnMoved;
        }


        private void OnGameStarted()
        {
            SpawnNewCoins(1);
        }


        private void OnMoved(Vector2Int headPosition)
        {
            var eaten = _coins.FirstOrDefault(coin => _snake.HeadPosition == coin.Position);

            if (eaten == null) return;

            _snake.Expand(eaten.Bones);
            _score.Add(eaten.Score);
            RemoveCoin(eaten);

            if (_coins.Count > 0) return;

            if (!_difficulty.Next(out var difficulty))
            {
                Debug.LogWarning("No difficulty available. PLAYER SHOULD WIN!");
                return;
            }
            
            SpawnNewCoins(difficulty);
        }


        private void OnGameFinished()
        {
            _snake.OnMoved -= OnMoved;
        }


        private void SpawnNewCoins(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var coin = SpawnNewCoin();
                _coins.Add(coin);
            }
        }


        private void RemoveCoin(Coin coin)
        {
            if (coin == null) return;

            _coins.Remove(coin);
            _coinSpawner.Despawn(coin);
        }


        private Coin SpawnNewCoin()
        {
            var position = _worldBounds.GetRandomPosition();
            var parent = _worldBounds.transform;

            return _coinSpawner.Spawn(position, parent);
        }


        public void Dispose()
        {
            _playerSpawner.OnPlayerSpawned -= OnPlayerSpawned;

            _gameLoop.OnGameStarted -= OnGameStarted;
            _gameLoop.OnGameFinished -= OnGameFinished;
        }
    }
}