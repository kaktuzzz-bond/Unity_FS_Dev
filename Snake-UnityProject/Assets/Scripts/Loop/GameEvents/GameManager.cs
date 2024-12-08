using System;
// using Input.InputMaps;
using UnityEngine;
using Zenject;

namespace Loop
{
    public class GameManager : ITickable
    {
        public event Action OnGameStarted;
        public event Action OnGameFinished;
        public bool IsInProgress { get; private set; }

        // private readonly GameLoopMap _gameLoopMap;
        //
        //
        // public GameManager(GameLoopMap gameLoopMap)
        // {
        //     _gameLoopMap = gameLoopMap;
        // }


        private void Start()
        {
            IsInProgress = true;
            OnGameStarted?.Invoke();
        }


        public void Finish()
        {
            IsInProgress = false;
            OnGameFinished?.Invoke();
        }


        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Start();
            }
        }
    }
}