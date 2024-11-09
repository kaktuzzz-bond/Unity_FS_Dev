using System;
using UnityEngine;

namespace Gameplay.Management
{
    public class TimeScaler : MonoBehaviour
    {
        [SerializeField] private GameCycle gameCycle;

        private void OnEnable()
        {
            gameCycle.OnGameCycleStateChanged += ChangeTimeScale;
        }

        private void ChangeTimeScale(bool isActive)
        {
            var state = isActive ? "STARTED" : "FINISHED";
            Debug.Log($"::GAME {state}");
            
            Time.timeScale = isActive ? 1f : 0f;
        }

        private void OnDisable()
        {
            gameCycle.OnGameCycleStateChanged += ChangeTimeScale;
        }
    }
}