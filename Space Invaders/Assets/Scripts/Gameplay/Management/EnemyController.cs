using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Factories;
using Gameplay.Spaceships;
using Modules.Extensions;
using UnityEngine;

namespace Gameplay.Management
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        private const float MinSpawnDelay = 1f;
        private const float MaxSpawnDelay = 2f;
        private const int MaxActiveEnemies = 4;

        private readonly HashSet<SpaceshipBase> _enemies = new();
        private SpaceshipFactory _spaceshipFactory;
        private SpaceshipBase _player;
        private bool _isSpawning;

        public void Initialize(SpaceshipFactory spaceshipFactory, SpaceshipBase player)
        {
            _spaceshipFactory = spaceshipFactory;
            _player = player;

            _isSpawning = true;

            StartCoroutine(SpawnEnemyRoutine());
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            while (_isSpawning)
            {
                yield return new WaitForSeconds(Random.Range(MinSpawnDelay, MaxSpawnDelay));

                var activeCount = _enemies.Count(x => x.gameObject.activeSelf);

                if (activeCount <= MaxActiveEnemies)
                {
                    SpawnEnemy();
                }
            }
        }

        private void SpawnEnemy()
        {
            var spawnPosition = spawnPositions.GetRandomItem().position;
            var attackPosition = attackPositions.GetRandomItem().position;

            var unit = _spaceshipFactory.SpawnEnemy(spawnPosition)
                .SetDestination(attackPosition)
                .SetTarget(_player.transform);

            _enemies.Add(unit);
        }
    }
}