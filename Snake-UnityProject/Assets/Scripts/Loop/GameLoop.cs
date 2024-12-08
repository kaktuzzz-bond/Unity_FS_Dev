using System;
using Input.InputMaps;
using Modules.Difficulty;
using Modules.Score;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Loop
{
    public class GameLoop : ITickable
    {
        public event Action OnGameStarted;
        public event Action OnGameFinished;
        public bool IsInProgress { get; private set; }

        private readonly GameLoopMap _gameLoopMap;
       


        public GameLoop(GameLoopMap gameLoopMap)
        {
            _gameLoopMap = gameLoopMap;
        }


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
            if (UnityEngine.Input.GetKeyDown(_gameLoopMap.StartGame))
            {
                Start();
            }
        }
    }
}