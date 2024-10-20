using System.Collections;
using Extensions;
using Modules.Factories;
using Modules.Spaceships;
using UnityEngine;

namespace Gameplay
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        private const float MinSpawnDelay = 1f;
        private const float MaxSpawnDelay = 2f;
        
        private SpaceshipFactory _spaceshipFactory;
        private SpaceshipBase _player;
        private bool _isSpawning;

        public void Initialize( SpaceshipFactory spaceshipFactory, SpaceshipBase player)
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

                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var spawnPosition = spawnPositions.GetRandomItem().position;
            var attackPosition = attackPositions.GetRandomItem().position;

            _spaceshipFactory.SpawnEnemy(spawnPosition)
                .SetDestination(attackPosition)
                .SetTarget(_player.transform);
        }
    }
}