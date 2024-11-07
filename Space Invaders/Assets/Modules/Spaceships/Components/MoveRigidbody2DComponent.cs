using UnityEngine;

namespace Modules.Spaceships.Components
{
    public class MoveRigidbody2DComponent
    {
        public Vector2 TargetPosition { get; private set; }
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        public MoveRigidbody2DComponent(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector2 direction, float deltaTime)
        {
            TargetPosition = _rigidbody.position + direction * _speed * deltaTime;

            _rigidbody.MovePosition(TargetPosition);
        }
    }
}