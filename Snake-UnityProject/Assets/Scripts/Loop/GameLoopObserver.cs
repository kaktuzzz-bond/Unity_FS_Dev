using System;
using Player;
using Zenject;

namespace Loop
{
    public class GameLoopObserver : IInitializable, IDisposable
    {
        private readonly GameLoop _gameLoop;
        private readonly IDeathObserver _playerDeathObserver;


        public GameLoopObserver(GameLoop gameLoop, IDeathObserver playerDeathObserver)
        {
            _gameLoop = gameLoop;
            _playerDeathObserver = playerDeathObserver;
        }


        public void Initialize()
        {
            _playerDeathObserver.OnDeath += _gameLoop.Finish;
        }


        public void Dispose()
        {
            _playerDeathObserver.OnDeath -= _gameLoop.Finish;
        }
    }
}