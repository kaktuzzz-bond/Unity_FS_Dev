using Game.Scripts.Components.Flip;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Move
{
    public class MoveComponent : IMoveComponent, ITickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private Vector3 _direction;
        private bool _canMove = true;

        public MoveComponent(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void SetDirection(Vector3 direction) => _direction = direction;

        private void Move() => _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

        public void Tick()
        {
            if (!_canMove) return;

            Move();
        }
    }
}