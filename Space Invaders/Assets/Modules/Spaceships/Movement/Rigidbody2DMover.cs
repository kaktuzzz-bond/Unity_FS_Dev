using UnityEngine;

namespace Modules.Spaceships.Movement
{
    public class Rigidbody2DMover : IMoveService
    {
        private readonly Rigidbody2D _rigidbody;
        public Vector2 TargetPosition { get; private set; }
        
        private readonly float _speed;

        public Rigidbody2DMover(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody = rigidbody2D;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            TargetPosition = _rigidbody.position + direction * _speed * Time.fixedDeltaTime;

            _rigidbody.MovePosition(TargetPosition);
        }
    }
}