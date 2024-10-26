using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Spaceships;
using Modules.Extensions;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Gameplay.Management
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        [SerializeField] private SpaceshipSpawner spaceshipSpawner;

        private const float MinSpawnDelay = 1f;
        private const float MaxSpawnDelay = 2f;
        private const int MaxActiveEnemies = 4;

        private readonly HashSet<Spaceship> _enemies = new();
        private Spaceship _player;
        private bool _isSpawning;


        private void Awake()
        {
        }

        public void Initialize(Spaceship player)
        {
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

            // var unit = _spaceshipFactory.SpawnEnemy(spawnPosition)
            //     .SetDestination(attackPosition)
            //     .SetTarget(_player.transform);

            // _enemies.Add(unit);
        }
    }
}