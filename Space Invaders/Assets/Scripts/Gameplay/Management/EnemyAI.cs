using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Spaceships;
using Gameplay.Spaceships.Components;
using Modules.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Management
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        [SerializeField] private SpaceshipSpawner spaceshipSpawner;
        [SerializeField] private PlayerService playerService;

        private const float MinSpawnDelay = 1f;
        private const float MaxSpawnDelay = 2f;
        private const int MaxActiveEnemies = 4;

        private readonly HashSet<Spaceship> _enemies = new();
        private bool _isSpawning;


        public void StartSpawning()
        {
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
            
            var spaceship = spaceshipSpawner.Create(spawnPosition)
                .SetTarget(playerService.Player.transform)
                .SetActive(true);

            if (spaceship.TryGetComponent(out EnemyDriverComponent driver))
            {
                var attackPosition = attackPositions.GetRandomItem().position;
                driver.SetAttackPosition(attackPosition);
            }

            _enemies.Add(spaceship);
        }
    }
}