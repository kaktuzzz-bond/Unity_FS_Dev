using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Management
{
    public class GameManager : ITickable
    {
        public event Action OnGameStarted;
        public event Action OnGameFinished;


        private void Start()
        {
            OnGameStarted?.Invoke();
        }


        public void Finish()
        {
            OnGameFinished?.Invoke();
        }


        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                Start();
            }
        }
    }
}