using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class JumpUseCase : IJumpable, IInitializable, ITickable
    {
        private readonly Rigidbody2D _rb;
        private readonly float _jumpHeight;
        private readonly float _fallGravityScale;
        private float _defaultGravityScale;
        private float _jumpForce;
        

        public JumpUseCase(Rigidbody2D rb, float jumpHeight, float fallGravityScale)
        {
            _rb = rb;
            _jumpHeight = jumpHeight;
            _fallGravityScale = fallGravityScale;
        }

        public void Initialize()
        {
            _defaultGravityScale = _rb.gravityScale;
            _jumpForce = Mathf.Sqrt(_jumpHeight *
                                    Mathf.Abs(Physics2D.gravity.y * _defaultGravityScale * 2)) *
                         _rb.mass;
        }

        public void Tick()
        {
            _rb.gravityScale = _rb.velocity.y > 0 ? _defaultGravityScale : _fallGravityScale;
        }

        public void Jump()
        {
            Jump(Vector2.up, _jumpForce);
        }

        private void Jump(Vector2 direction, float force)
        {
            _rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}