using System;
using Loop;
using Modules.Snake;
using Modules.World;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerSpawner : IPlayerProvider
    {
        public event Action<ISnake> OnPlayerSpawned;

        private readonly Transform _worldTransform;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerDeathObserver _playerDeathObserver;


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
            var player = _playerFactory.Create();

            player.transform.SetParent(_worldTransform);

            _playerDeathObserver.StartObserving(player);

            OnPlayerSpawned?.Invoke(player);

            return player;
        }


        public class PlayerFactory : PlaceholderFactory<Snake>
        {
        }
    }
}