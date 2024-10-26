using System;
using Gameplay.Spaceships;
using Gameplay.Spaceships.Components;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private DamageComponent damageComponent;
        [SerializeField] private CollisionDataComponent collisionDataComponent;
        
        private Vector2 _velocity;
        private ObjectPool<Bullet> _parentPool;
        private Transform _parent;
        private void Awake()
        {
            SetLayerMask();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Spaceship unit))
            {
                unit.TakeDamage(damageComponent.Damage);
            }

            ReturnToPool();
        }

        public Bullet SetParent(Transform parent)
        {
            _parent = parent;
            return this;
        }
      
        public Bullet SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
            return this;
        }

        public Bullet SetPosition(Vector2 position)
        {
            transform.position = position;
            return this;
        }

        public Bullet SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
            return this;
        }

        public Bullet SetParentPool(ObjectPool<Bullet> parentPool)
        {
            _parentPool = parentPool;
            return this;
        }

        private void ReturnToPool()
        {
            _parentPool.Despawn(this);
            SetActive(false);
        }

        private void SetLayerMask()
        {
            gameObject.layer = collisionDataComponent.CollisionLayer;
        }
    }
}