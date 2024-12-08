using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Player;
using Gameplay.World;
using UnityEngine;
using Zenject;

namespace Gameplay.Management
{
    public class GameEventManager : IInitializable, IDisposable
    {
        private readonly DiContainer _container;

        private GameManager _gameManager;

        private IDeathObserver _deathObserver;

        private ICoinCollector _coinCollector;

        private HashSet<IGameListener> _listeners = new();


        public GameEventManager(DiContainer container)
        {
            _container = container;
        }


        public void Initialize()
        {
            _listeners = _container.ResolveAll<IGameListener>().ToHashSet();

            _gameManager = _container.Resolve<GameManager>();

            _deathObserver = _container.Resolve<IDeathObserver>();

            _coinCollector = _container.Resolve<ICoinCollector>();

            Debug.Log($"Listeners count: {_listeners.Count}");

            _gameManager.OnGameStarted += OnGameStarted;
            _gameManager.OnGameFinished += OnGameFinished;
            _deathObserver.OnPlayerDeath += OnGameFailed;
            _coinCollector.OnGameWon += OnGameWon;
        }


        private void OnGameStarted()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameStartedListener listener)
                    listener.OnGameStarted();
            }
        }


        private void OnGameFailed()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameFailedListener listener)
                    listener.OnGameFailed();
            }

            _gameManager.Finish();
        }


        public void OnGameWon()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameWonListener listener)
                    listener.OnGameWon();
            }

            _gameManager.Finish();
        }


        private void OnGameFinished()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameFinishedListener listener)
                    listener.OnGameFinished();
            }
        }


        public void Dispose()
        {
            _gameManager.OnGameStarted -= OnGameStarted;
            _gameManager.OnGameFinished -= OnGameFinished;
            _deathObserver.OnPlayerDeath -= OnGameFailed;
            _coinCollector.OnGameWon -= OnGameWon;
        }
    }
}