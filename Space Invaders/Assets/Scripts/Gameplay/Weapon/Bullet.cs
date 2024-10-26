using System;
using Gameplay.Spaceships;
using Gameplay.Spaceships.Components;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Weapon
{
    public sealed class Bullet : MonoBehaviour, IPoolReleasable<Bullet>
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private DamageComponent damageComponent;
        [SerializeField] private CollisionDataComponent collisionDataComponent;

        public Action<Bullet> OnRelease { get; set; }
        
        public Vector2 Velocity
        {
            set => rigidbody2D.velocity = value;
        }

        public bool Activity
        {
            set => gameObject.SetActive(value);
        }

      

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

            OnRelease?.Invoke(this);
        }

      
        public void SetReleaseAction(Action<Bullet> action)
        {
            OnRelease = action;
        }
     

        private void SetLayerMask() =>
            gameObject.layer = collisionDataComponent.CollisionLayer;

      
    }
}