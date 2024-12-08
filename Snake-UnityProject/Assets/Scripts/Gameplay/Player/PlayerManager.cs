using Gameplay.Management;
using Input;
using Modules.Difficulty;
using Modules.Snake;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public sealed class PlayerManager : IGameStartedListener, IGameFinishedListener, ITickable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerSpawner _playerSpawner;
        private readonly IDifficulty _difficulty;

        private ISnake _snake;
        private bool _isInputAllowed;


        public PlayerManager(IPlayerInput playerInput, IPlayerSpawner playerSpawner, IDifficulty difficulty)
        {
            _playerInput = playerInput;
            _playerSpawner = playerSpawner;
            _difficulty = difficulty;
        }


        public void OnGameStarted()
        {
            if (_snake != null) return;

            _snake = _playerSpawner.SpawnPlayer();

            _isInputAllowed = true;

            _difficulty.OnStateChanged += OnDifficultyChanged;
        }


        private void OnDifficultyChanged()
        {
            var speed = _difficulty.Current;
            _snake.SetSpeed(speed);

            Debug.Log($"Set speed: [{speed}]");
        }


        public void OnGameFinished()
        {
            _isInputAllowed = false;

            _snake.SetSpeed(0f);

            _playerSpawner.DespawnPlayer();

            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }


        public void Tick()
        {
            if (!_isInputAllowed || _snake == null) return;

            var direction = _playerInput.GetDirection();

            _snake.Turn(direction);
        }
    }
}