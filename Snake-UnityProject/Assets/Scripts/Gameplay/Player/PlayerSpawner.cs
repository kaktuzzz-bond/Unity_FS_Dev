using System;
using Modules.Snake;
using Zenject;
using Object = UnityEngine.Object;

namespace Gameplay.Player
{
    public class PlayerSpawner : IPlayerSpawner
    {
        public event Action<ISnake> OnPlayerSpawned;

        private readonly WorldPoint _worldPoint;

        private readonly PlayerFactory _playerFactory;


        private Snake _snake;


        public PlayerSpawner(WorldPoint worldPoint, PlayerFactory playerFactory)
        {
            _worldPoint = worldPoint;
            _playerFactory = playerFactory;
        }


        public ISnake SpawnPlayer()
        {
            _snake = _playerFactory.Create();

            _snake.transform.SetParent(_worldPoint.Value);

            OnPlayerSpawned?.Invoke(_snake);

            return _snake;
        }


        public void DespawnPlayer()
        {
            if (_snake == null) return;

            Object.Destroy(_snake.gameObject);
        }


        public class PlayerFactory : PlaceholderFactory<Snake>
        {
        }
    }
}