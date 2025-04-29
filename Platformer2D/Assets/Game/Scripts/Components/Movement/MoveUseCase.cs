using UnityEngine;

namespace Game.Scripts.Components.Movement
{
    public class MoveUseCase : IMovable
    {
        private readonly Rigidbody2D _rb;
        private readonly Transform _body;
        private readonly float _speed;
        private readonly bool _isFlippable;
        private Vector3 _direction = Vector3.one;

        public MoveUseCase(Rigidbody2D rb, Transform body, float speed, bool isFlippable)
        {
            _rb = rb;
            _body = body;
            _speed = speed;
            _isFlippable = isFlippable;
        }

        public Vector3 GetDirection => _direction;

        public void MoveX(float xDirection)
        {
            Move(new Vector2(xDirection * _speed, _rb.velocity.y));
        }


        public void Move(Vector3 direction)
        {
            _rb.velocity = direction;

            if (_isFlippable)
            {
                LookTowardsX(direction.x);
            }
        }


        private void LookTowardsX(float direction)
        {
            if (direction == 0) return;
            _direction.x = direction < 0 ? -1 : 1;
            _body.localScale = _direction;
        }
    }
}