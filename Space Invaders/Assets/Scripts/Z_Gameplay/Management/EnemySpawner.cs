using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Modules.Extensions;
using UnityEngine;
using Z_Gameplay.Spaceships;
using Random = UnityEngine.Random;

namespace Z_Gameplay.Management
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        [SerializeField] private SpaceshipSpawner spaceshipSpawner;
        [SerializeField] private PlayerService playerService;

        [SerializeField] private float minSpawnDelay = 1f;
        [SerializeField] private float maxSpawnDelay = 2f;
        [SerializeField] private int maxActiveEnemies = 4;

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
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                
                var activeCount = _enemies.Count(x => x.gameObject.activeSelf);

                if (activeCount <= maxActiveEnemies)
                {
                    SpawnEnemy();
                }
            }
        }

        private void SpawnEnemy()
        {
            var spawnPosition = spawnPositions.GetRandomItem().position;
            
            // var spaceship = spaceshipSpawner.Rent(spawnPosition,Quaternion.identity)
            //     .SetTarget(playerService.Player.transform)
            //     .SetActive(true);
            //
            // if (spaceship.TryGetComponent(out EnemyAIComponent driver))
            // {
            //     var attackPosition = attackPositions.GetRandomItem().position;
            //     driver.SetAttackPosition(attackPosition);
            // }
            //
            // _enemies.Add(spaceship); 
        }
    }
}