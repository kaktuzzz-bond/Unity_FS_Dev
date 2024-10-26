using Modules.Levels;
using Modules.PlayerInput;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Management
{
    public sealed class GameManager : MonoBehaviour
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

            Time.timeScale = 1;
        }

        private void GameOver()
        {
            Debug.LogWarning("GAME OVER");
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            // playerManager.Player.OnHealthEmpty -= GameOver;
        }
    }
}