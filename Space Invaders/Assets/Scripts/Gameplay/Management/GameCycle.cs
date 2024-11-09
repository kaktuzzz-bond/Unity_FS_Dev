using System;
using Gameplay.Enemy;
using Gameplay.Player;
using Modules.Levels;
using UnityEngine;

namespace Gameplay.Management
{
    public class GameCycle : MonoBehaviour
    {
        public event Action<bool> OnGameCycleStateChanged;

        [SerializeField] private PlayerService playerService;
        [SerializeField] private EnemyService enemyService;
        [SerializeField] private LevelBackground levelBackground;

        private void OnEnable()
        {
            playerService.OnPlayerDeath += FinishGameCycle;
        }

        public void Start()
        {
            OnGameCycleStateChanged?.Invoke(true);
            playerService.AddPlayer();
            levelBackground.StartMoving();
            enemyService.StartSpawning();
        }
        
        private void FinishGameCycle()
        {
            OnGameCycleStateChanged?.Invoke(false);
        }

        private void OnDisable()
        {
            playerService.OnPlayerDeath -= FinishGameCycle;
        }
    }
}