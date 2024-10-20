using System.Collections;
using Modules.Enemies;
using Modules.PlayerInput;
using Modules.Units;
using UnityEngine;

namespace Gameplay
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        [SerializeField] private BulletFactory bulletFactory;
        [SerializeField] private SpaceshipFactory spaceshipFactory;
        
        [SerializeField] private InputListener inputListener;

        private SpaceshipBase _player;

        private void Awake()
        {
            bulletFactory.Initialize();
            spaceshipFactory.Initialize(bulletFactory);
            _player = spaceshipFactory.SpawnPlayer();

            _player.OnHealthEmpty += GameOver;
        }

        private void Start()
        {
            StartGame();
            StartCoroutine(SpawnEnemyCoroutine());
        }

        private void OnEnable()
        {
            inputListener.OnFirePressed += OnFirePressedHandler;
            inputListener.OnLeftPressed += OnLeftPressedHandler;
            inputListener.OnRightPressed += OnRightPressedHandler;
        }

        private void OnFirePressedHandler()
        {
            _player.Attack();
        }

        private void OnLeftPressedHandler()
        {
            _player.Move(Vector2.left);
        }

        private void OnRightPressedHandler()
        {
            _player.Move(Vector2.right);
        }


        private void StartGame()
        {
            Debug.Log("GAME STARTED");
            Time.timeScale = 1;
        }

        private void GameOver()
        {
            Debug.LogWarning("GAME OVER");
            Time.timeScale = 0;
        }

        private IEnumerator SpawnEnemyCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));

                var spawnPosition = Utils.GetRandomFrom(spawnPositions).position;
                var attackPosition = Utils.GetRandomFrom(attackPositions);

                spaceshipFactory.SpawnEnemy(spawnPosition)
                    .SetDestination(attackPosition.position)
                    .SetTarget(_player.transform);
            }
        }

        private void OnDisable()
        {
            inputListener.OnFirePressed -= OnFirePressedHandler;
            inputListener.OnLeftPressed -= OnLeftPressedHandler;
            inputListener.OnRightPressed -= OnRightPressedHandler;
        }
    }
}