using UnityEngine;

namespace Game.Scripts.Components
{
    public class JumpComponent : IJumpComponent
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