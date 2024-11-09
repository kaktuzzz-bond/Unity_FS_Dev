using System;
using Gameplay.Spaceships;
using Modules.Extensions;
using UnityEngine;

namespace Gameplay.Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Bullet : MonoBehaviour
    {
        public event Func<Bullet, bool> OnTargetReached;

        [SerializeField] private SpriteRenderer spriteRenderer;


        private Rigidbody2D _rigidbody;
        private BulletConfig _config;

        public void Initialize(BulletConfig config)
        {
            _config = config;
            _rigidbody = GetComponent<Rigidbody2D>();
            spriteRenderer.sprite = _config.sprite;
            spriteRenderer.color = _config.color;
            gameObject.layer = _config.layerMask.LayerMaskToInt();
        }


        public void Launch(Vector2 direction)
        {
            _rigidbody.velocity = direction * _config.speed;
        }

        public void SetPosition(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ISpaceship unit))
            {
                unit.TakeDamage(_config.damage);
            }

            OnTargetReached?.Invoke(this);
        }
    }
}