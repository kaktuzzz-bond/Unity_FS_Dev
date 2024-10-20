using System.Collections;
using Modules.Enemies;
using Modules.PlayerInput;
using Modules.Units;
using UnityEngine;

namespace Gameplay
{
    public sealed class BattleManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        [SerializeField] private BulletFactory bulletFactory;
        [SerializeField] private SpaceshipFactory spaceshipFactory;

        [SerializeField] private InputListener inputListener;

        [SerializeField] private int bulletPoolSize = 10;
        [SerializeField] private int spaceshipPoolSize = 7;

        private SpaceshipBase _player;

        private void Awake()
        {
            bulletFactory.Initialize(bulletPoolSize);
            spaceshipFactory.Initialize(spaceshipPoolSize, bulletFactory);
            _player = spaceshipFactory.SpawnPlayer();

            _player.OnHealthEmpty += _ => Time.timeScale = 0;
        }

        private void Start()
        {
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