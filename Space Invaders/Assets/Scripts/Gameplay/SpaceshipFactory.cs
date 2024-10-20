using Modules.Enemies;
using Modules.Player;
using Modules.Units;
using UnityEngine;

namespace Gameplay
{
    public class SpaceshipFactory : MonoBehaviour
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Enemy enemyPrefab;
        
        [SerializeField] private Transform playerParent;
        [SerializeField] private Transform enemyParent;
        
        private ObjectPool<Enemy> _enemyPool;
       
        public void Initialize(int capacity)
        {
           // _enemyPool = new ObjectPool<Enemy>(prefab, parent, capacity);
        }

        public void SpawnEnemy()
        {
            var enemy = _enemyPool.Spawn();
        }
    }
}