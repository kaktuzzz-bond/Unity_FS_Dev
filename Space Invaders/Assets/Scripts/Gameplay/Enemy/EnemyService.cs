using System.Collections;
using Modules.Extensions;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private EnemySpawnSettings spawnSettings;
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private SpaceshipSpawner enemySpawner;
        [SerializeField] private EnemyAI enemyAI;
        
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
                var delay = Random.Range(spawnSettings.minSpawnDelay, spawnSettings.maxSpawnDelay);
                yield return new WaitForSeconds(delay);
                
                if (enemyAI.EnemyCount < spawnSettings.maxActiveEnemies)
                {
                    Debug.Log($"Enemy Count: {enemyAI.EnemyCount} <= {spawnSettings.maxActiveEnemies}");
                    SpawnEnemy();
                }
            }
        }

        private void SpawnEnemy()
        {
            var spawnPosition = spawnPositions.GetRandomItem().position;

            var spaceship = enemySpawner.Rent();
            spaceship.SetPositionAndRotation(spawnPosition, Quaternion.identity);
            enemyAI.AddEnemy(spaceship);
            
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