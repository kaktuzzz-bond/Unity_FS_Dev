using System;
using Gameplay.Spaceships;
using Gameplay.Spaceships.Components;
using UnityEngine;

namespace Gameplay.Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private DamageComponent damageComponent;
        [SerializeField] private CollisionDataComponent collisionDataComponent;


        private string _targetTag;
        private Vector2 _velocity;
        private Action _onHit;

        private void Awake()
        {
            gameObject.layer = collisionDataComponent.layerMask;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Spaceship unit) &&
                unit.CompareTag(_targetTag))
            {
                unit.TakeDamage(damageComponent.Damage);
            }

            _onHit?.Invoke();
        }


        public Bullet SetTargetTag(string targetTag)
        {
            _targetTag = targetTag;
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


        public Bullet SetActionOnHit(Action action)
        {
            action += () => SetActive(false);
            _onHit = action;
            return this;
        }
    }
}