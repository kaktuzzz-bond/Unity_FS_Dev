using System;
using Modules.Enemies;
using UnityEngine;

namespace Modules.Units
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private string _targetTag;
        private int _damage;
        private Vector2 _velocity;
        private Action _onHit;

        public Bullet SetDamage(int damage)
        {
            _damage = damage;
            return this;
        }

        public Bullet SetColor(Color color)
        {
            spriteRenderer.color = color;
            return this;
        }

        public Bullet SetTargetTag(string targetTag)
        {
            _targetTag = targetTag;
            return this;
        }

        public Bullet SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
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

        public Bullet Activate()
        {
            gameObject.SetActive(true);
            return this;
        }

        public Bullet Deactivate()
        {
            gameObject.SetActive(false);
            return this;
        }

        public Bullet SetActionOnHit(Action action)
        {
            action += () => Deactivate();
            _onHit = action;
            return this;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out UnitBase unit)) return;

            if (!unit.CompareTag(_targetTag)) return;
            
            unit.TakeDamage(_damage);
            _onHit?.Invoke();
        }
    }
}