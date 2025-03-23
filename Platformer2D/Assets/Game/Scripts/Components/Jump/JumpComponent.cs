using UnityEngine;

namespace Game.Scripts.Components.Jump
{
    public class JumpComponent : IJumpable
    {
        private readonly Rigidbody2D _rigidbody;


        private readonly float _jumpForce;

        public JumpComponent(Rigidbody2D rigidbody, float jumpForce)
        {
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;
        }

        public void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}