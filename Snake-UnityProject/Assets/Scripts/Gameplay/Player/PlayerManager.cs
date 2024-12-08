using Gameplay.Management;
using Input;
using Modules.Snake;
using Zenject;

namespace Gameplay.Player
{
    public sealed class PlayerManager : IGameStartedListener, IGameFinishedListener, ITickable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IPlayerSpawner _playerSpawner;

        private ISnake _snake;
        private bool _isInputAllowed;


        public PlayerManager(IPlayerInput playerInput, IPlayerSpawner playerSpawner)
        {
            _playerInput = playerInput;
            _playerSpawner = playerSpawner;
        }


        public void OnGameStarted()
        {
            if (_snake != null) return;

            _snake = _playerSpawner.SpawnPlayer();

            _isInputAllowed = true;
        }


        public void OnGameFinished()
        {
            _isInputAllowed = false;
            
            _snake.SetSpeed(0f);
            
            _playerSpawner.DespawnPlayer();
        }


        public void Tick()
        {
            if (!_isInputAllowed || _snake == null) return;

            var direction = _playerInput.GetDirection();

            _snake.Turn(direction);
        }
    }
}