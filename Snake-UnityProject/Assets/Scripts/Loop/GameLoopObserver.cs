using System;
using Player;
using Zenject;

namespace Loop
{
    public class GameLoopObserver : IInitializable, IDisposable
    {
        private readonly GameManager _gameManager;
        private readonly IDeathObserver _playerDeathObserver;


        public GameLoopObserver(GameManager gameManager, IDeathObserver playerDeathObserver)
        {
            _gameManager = gameManager;
            _playerDeathObserver = playerDeathObserver;
        }


        public void Initialize()
        {
            _playerDeathObserver.OnDeath += _gameManager.Finish;
        }


        public void Dispose()
        {
            _playerDeathObserver.OnDeath -= _gameManager.Finish;
        }
    }
}