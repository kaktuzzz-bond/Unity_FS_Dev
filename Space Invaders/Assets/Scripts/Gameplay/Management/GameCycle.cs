using Modules.Levels;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Management
{
    public sealed class GameCycle : MonoBehaviour
    {
        [SerializeField] private PlayerService playerService;
        [SerializeField] private PlayerStateObserver playerStateObserver;
        [FormerlySerializedAs("enemyAI")] [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private LevelBackground levelBackground;


        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Debug.Log("GAME STARTED");

            playerService.SpawnPlayer();

            playerStateObserver.StartObserving();

            enemySpawner.StartSpawning();

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