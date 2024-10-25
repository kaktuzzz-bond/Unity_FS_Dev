using Modules.Levels;
using Modules.PlayerInput;
using UnityEngine;

namespace Gameplay.Management
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private FactoryController factoryController;
        [SerializeField] private LevelBackground levelBackground;

        private void Awake()
        {
            factoryController.Initialize();
            playerController.Initialize(factoryController.SpaceshipFactory, inputListener);
            enemyController.Initialize(factoryController.SpaceshipFactory, playerController.Player);
        }

        private void OnEnable()
        {
            playerController.Player.OnHealthEmpty += GameOver;
        }


        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Debug.Log("GAME STARTED");
            levelBackground.Initialize();
            Time.timeScale = 1;
        }

        private void GameOver()
        {
            Debug.LogWarning("GAME OVER");
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            playerController.Player.OnHealthEmpty -= GameOver;
        }
    }
}