using Modules.Levels;
using Modules.PlayerInput;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Management
{
    public sealed class GameCycle : MonoBehaviour
    {
        [SerializeField] private EnemyAI enemyAI;
        [SerializeField] private PlayerService playerService;
        [SerializeField] private LevelBackground levelBackground;


        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Debug.Log("GAME STARTED");
            
            playerService.SpawnPlayer();
            enemyAI.StartSpawning();
            levelBackground.StartMoving();

            Time.timeScale = 1;
        }

        public void GameOver()
        {
            Debug.LogWarning("GAME OVER");
            
            Time.timeScale = 0;
        }
        
    }
}