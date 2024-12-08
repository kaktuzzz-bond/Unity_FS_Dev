using System;
using Loop;
using Modules.Snake;
using Modules.World;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Player
{
    public class PlayerSpawner : IPlayerSpawner
    {
        public event Action<ISnake> OnPlayerSpawned;

        private readonly Transform _worldTransform;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerDeathObserver _playerDeathObserver;

        private Snake _snake;


        public PlayerSpawner(WorldBounds worldBounds,
                             PlayerFactory playerFactory,
                             PlayerDeathObserver playerDeathObserver)
        {
            _worldTransform = worldBounds.transform;
            _playerFactory = playerFactory;
            _playerDeathObserver = playerDeathObserver;
        }


        public ISnake SpawnPlayer()
        {
            _snake = _playerFactory.Create();

            _snake.transform.SetParent(_worldTransform);

            _playerDeathObserver.StartObserving(_snake);

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