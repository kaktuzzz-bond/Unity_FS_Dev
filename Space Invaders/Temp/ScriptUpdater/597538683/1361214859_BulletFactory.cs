using System.Collections.Generic;
using Modules.Bullets;
using Modules.Levels;
using UnityEngine;

namespace Gameplay
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField]
        private Bullet prefab;
        [SerializeField]
        private Transform parent;
        
        [SerializeField]
        private LevelBounds levelBounds;
        
        private readonly Queue<Bullet> _bulletPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < 10; i++)
            {
                var bullet = Instantiate(prefab, parent);
                _bulletPool.Enqueue(bullet);
            }
        }
        
        //enemy
        // _bulletSystem.SpawnBullet(
        // position,
        // Color.red,
        // (int) PhysicsLayer.EnemyBullet,
        // 1,
        // false,
        // direction * 2
        // );
        
        //player
        // bulletManager.SpawnBullet(
        // firePoint.position,
        // Color.blue,
        // (int)PhysicsLayer.PlayerBullet,
        // 1,
        // true,
        // firePoint.rotation * Vector3.up * 3
        // );
        
        public void SpawnBullet(
            Vector2 position,
            Color color,
            int physicsLayer,
            int damage,
            bool isPlayer,
            Vector2 velocity
        )
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.parent);
            }
            else
            {
                bullet = Instantiate(this.prefab, this.parent);
            }

            bullet.transform.position = position;
            bullet.spriteRenderer.color = color;
            bullet.gameObject.layer = physicsLayer;
            bullet.damage = damage;
            bullet.isPlayer = isPlayer;
            bullet.GetComponent<Rigidbody2D>().velocity = velocity;

            if (m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
    }
}