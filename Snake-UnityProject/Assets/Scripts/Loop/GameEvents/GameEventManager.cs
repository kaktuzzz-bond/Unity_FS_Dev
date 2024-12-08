using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Loop.GameEvents
{
    public class GameEventManager : IInitializable, IDisposable
    {
        private readonly DiContainer _container;

        private GameManager _gameManager;

        private HashSet<IGameListener> _listeners = new();


        public GameEventManager(DiContainer container)
        {
            _container = container;
        }


        public void Initialize()
        {
            _listeners = _container.ResolveAll<IGameListener>().ToHashSet();

            _gameManager = _container.Resolve<GameManager>();

            _gameManager.OnGameStarted += OnGameStarted;
            _gameManager.OnGameFinished += OnGameStarted;

            Debug.Log($"Listeners count: {_listeners.Count}");
        }


        public void OnGameStarted()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameStartedListener listener)
                    listener.OnGameStarted();
            }
        }


        public void OnGameFailed()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameFailedListener listener)
                    listener.OnGameFailed();
            }
        }


        public void OnGameWon()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameWonListener listener)
                    listener.OnGameWon();
            }
        }


        public void OnGameFinished()
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
            _gameManager.OnGameFinished -= OnGameStarted;
        }
    }
}