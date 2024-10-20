using System;
using UnityEngine;

namespace Gameplay
{
    public sealed class GameManager : MonoBehaviour
    {
        public event Action OnGameStart;
        public event Action OnGameOver;

        public void StartGame()
        {
            Debug.Log("GAME STARTED");
            OnGameStart?.Invoke();
        } 
        public void GameOver()
        {
            Debug.Log("GAME OVER");
            OnGameOver?.Invoke();
        }
        
        
    }
}