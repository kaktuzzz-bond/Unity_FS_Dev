using System.Collections;
using System.Collections.Generic;
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
        
        //[SerializeField] private SpaceshipFactory spaceshipFactory;
        
        // [SerializeField]
        // private Player player;

        // [SerializeField]
        // private Transform worldTransform;
        //
        // [SerializeField]
        // private Transform container;
        //
        // [SerializeField]
        // private Enemy prefab;
        
        // [SerializeField]
        // private BulletManager _bulletSystem;
        
        // private readonly HashSet<Enemy> m_activeEnemies = new();
        // private readonly Queue<Enemy> enemyPool = new();
        
        // private void Awake()
        // {
        //     spaceshipFactory.Initialize(7);
        // }

       

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
        
    }
}