using System;
using Input.InputMaps;
using UnityEngine;
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


        public void Start()
        {
            IsInProgress = true;
            OnGameStarted?.Invoke();
            Debug.Log("GAME STARTED");
        }

        public void Finish()
        {
            IsInProgress = true;
            OnGameFinished?.Invoke();
            Debug.Log("GAME FINISHED");
        }
        
        // public void Stop()
        // {
        //     IsInProgress = false;
        //     Debug.Log("GAME PAUSED");
        // }
        //
        //
        // private void Resume()
        // {
        //     Start();
        //     Debug.Log("GAME RESUMED");
        // }
        //
        //
        // private void Exit()
        // {
        //     Stop();
        //     Debug.Log("EXIT GAME");
        // }


        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(_gameLoopMap.StartGame)) Start();
            
            // else if (UnityEngine.Input.GetKeyDown(_gameLoopMap.PauseGame)) Stop();
            // else if (UnityEngine.Input.GetKeyDown(_gameLoopMap.ResumeGame)) Resume();
            // else if (UnityEngine.Input.GetKeyDown(_gameLoopMap.ExitGame)) Exit();
        }
    }
}