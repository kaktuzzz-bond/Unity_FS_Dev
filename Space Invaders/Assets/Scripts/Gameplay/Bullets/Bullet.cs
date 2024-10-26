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

        public Vector2 Velocity
        {
            set => rigidbody2D.velocity = value;
        }

        public bool Activity
        {
            set => gameObject.SetActive(value);
        }

        private Action<Bullet> _release;

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

            _release?.Invoke(this);
        }


        public void SetReleaseAction(Action<Bullet> action) =>
            _release = action;


        private void SetLayerMask() =>
            gameObject.layer = collisionDataComponent.CollisionLayer;
    }
}