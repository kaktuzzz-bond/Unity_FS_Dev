using UnityEngine;

namespace Gameplay.Spaceships.Strategy
{
    public class MoveStrategy:IAIStrategy
    {
        private readonly Rigidbody2D _rigidbody;
        
        private readonly float _speed;

        public MoveStrategy(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody = rigidbody2D;
            _speed = speed;
        }

        public void Update(Vector2 direction)
        {
            var targetPosition = _rigidbody.position + direction * _speed * Time.fixedDeltaTime;

            _rigidbody.MovePosition(targetPosition);
        }
    }
}