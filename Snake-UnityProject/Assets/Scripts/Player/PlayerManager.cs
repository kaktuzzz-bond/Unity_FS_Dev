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
        private readonly GameManager _gameManager;

        private ISnake _snake;


        public PlayerManager(IPlayerInput playerInput, PlayerSpawner playerSpawner, GameManager gameManager)
        {
            _playerInput = playerInput;
            _playerSpawner = playerSpawner;
            _gameManager = gameManager;
        }


        public void Initialize()
        {
            _gameManager.OnGameStarted += OnGameStarted;
            _gameManager.OnGameFinished += OnGameFinished;
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
            _gameManager.OnGameStarted -= OnGameStarted;
            _gameManager.OnGameFinished -= OnGameFinished;
        }


        public void Tick()
        {
            if (!_gameManager.IsInProgress || _snake == null) return;

            var direction = _playerInput.GetDirection();

            _snake.Turn(direction);
        }
    }
}