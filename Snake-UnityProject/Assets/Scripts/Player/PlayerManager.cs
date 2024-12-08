using System;
using Input;
using Loop;
using Modules.Snake;
using UnityEngine;
using Zenject;

namespace Player
{
    public sealed class PlayerManager : IInitializable, IDisposable, ITickable
    {
        private readonly IPlayerInput _playerInput;
        private readonly PlayerSpawner _playerSpawner;
        private readonly GameLoop _gameLoop;

        private ISnake _snake;


        public PlayerManager(IPlayerInput playerInput, PlayerSpawner playerSpawner, GameLoop gameLoop)
        {
            _playerInput = playerInput;
            _playerSpawner = playerSpawner;
            _gameLoop = gameLoop;
        }


        public void Initialize()
        {
            _gameLoop.OnGameStarted += OnGameStarted;
            _gameLoop.OnGameFinished += OnGameFinished;
        }


        private void OnGameFinished()
        {
            _snake.SetSpeed(0f);
           _playerSpawner.DespawnPlayer();
        }


        private void OnGameStarted()
        {
            if (_snake != null) return;

            _snake = _playerSpawner.SpawnPlayer();
        }


        public void Dispose()
        {
            _gameLoop.OnGameStarted -= OnGameStarted;
            _gameLoop.OnGameFinished -= OnGameFinished;
        }


        public void Tick()
        {
            if (!_gameLoop.IsInProgress || _snake == null) return;

            var direction = _playerInput.GetDirection();

            _snake.Turn(direction);
        }
    }
}