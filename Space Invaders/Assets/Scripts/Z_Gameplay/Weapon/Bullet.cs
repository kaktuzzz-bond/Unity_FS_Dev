using System;
using UnityEngine;
using Z_Gameplay.Spaceships;
using Z_Gameplay.Spaceships.Components;

namespace Z_Gameplay.Weapon
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnTargetReached;

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private DamageComponent damageComponent;
        [SerializeField] private CollisionDataComponent collisionDataComponent;


        private void Awake()
        {
            SetLayerMask();
        }

        public Bullet SetVelocity(Vector2 velocity)
        {
            rigidbody2D.velocity = velocity;
            return this;
        }

        public Bullet SetSpriteAndColor(Sprite sprite, Color color)
        {
            spriteRenderer.sprite = sprite;
            spriteRenderer.color = color;
            return this;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Spaceship unit))
            {
                unit.TakeDamage(damageComponent.Damage);
            }

            OnTargetReached?.Invoke(this);
        }


        private void SetLayerMask() =>
            gameObject.layer = collisionDataComponent.CollisionLayer;
    }
}