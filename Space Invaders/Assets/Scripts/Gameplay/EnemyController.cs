using System.Collections;
using System.Collections.Generic;
using Modules.Player;
using Modules.Units;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace Gameplay
{
    public sealed class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private Transform[] attackPositions;
        
        [FormerlySerializedAs("enemyFactory")] [SerializeField] private SpaceshipFactory spaceshipFactory;
        
        [SerializeField]
        private Player player;

        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private Enemy prefab;
        
        // [SerializeField]
        // private BulletManager _bulletSystem;
        
        private readonly HashSet<Enemy> m_activeEnemies = new();
        private readonly Queue<Enemy> enemyPool = new();
        
        private void Awake()
        {
            spaceshipFactory.Initialize(7);
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));
                
                if (!enemyPool.TryDequeue(out Enemy enemy))
                {
                    enemy = Instantiate(prefab, container);
                }

                enemy.transform.SetParent(worldTransform);

                Transform spawnPosition = RandomPoint(this.spawnPositions);
                enemy.transform.position = spawnPosition.position;

                Transform attackPosition = RandomPoint(this.attackPositions);
                enemy.SetDestination(attackPosition.position);
                enemy.SetTarget(player.transform);

                if (m_activeEnemies.Count < 5 && m_activeEnemies.Add(enemy))
                {
                    enemy.OnFire += this.SpawnBullet;
                }
            }
        }

        private void FixedUpdate()
        {
            // foreach (Enemy enemy in m_activeEnemies.ToArray())
            // {
            //     if (enemy.health <= 0)
            //     {
            //         enemy.OnFire -= this.OnFire;
            //         enemy.transform.SetParent(this.container);
            //
            //         m_activeEnemies.Remove(enemy);
            //         this.enemyPool.Enqueue(enemy);
            //     }
            // }
        }

        private void SpawnBullet(Vector2 position, Vector2 direction)
        {
            // _bulletSystem.SpawnBullet(
            //     position,
            //     Color.red,
            //     (int) PhysicsLayer.EnemyBullet,
            //     1,
            //     false,
            //     direction * 2
            // );
        }

        private Transform RandomPoint(Transform[] points)
        {
            var index = Random.Range(0, points.Length);
            return points[index];
        }
    }
}