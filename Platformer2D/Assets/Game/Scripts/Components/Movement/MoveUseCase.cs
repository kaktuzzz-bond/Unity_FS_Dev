using UnityEngine;

namespace Game.Scripts.Components.Movement
{
    public class MoveUseCase : IMovable
    {
        private readonly Rigidbody2D _rb;
        private readonly Transform _body;
        private readonly float _speed;
        private readonly bool _isFlippable;
        private Vector3 _scale = Vector3.one;

        public MoveUseCase(Rigidbody2D rb, Transform body, float speed, bool isFlippable)
        {
            _rb = rb;
            _body = body;
            _speed = speed;
            _isFlippable = isFlippable;
        }

        public Vector3 GetDirection => new(_scale.x, 0);

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

        public void ForceMoveX(float value)
        {
            ForceMove(new Vector2(value, 0));
        }
        
        public void ForceMove(Vector2 force)
        {
            _rb.AddForce(force);
        }

        private void LookTowardsX(float direction)
        {
            if (direction == 0) return;
            _scale.x = direction < 0 ? -1 : 1;

            _body.localScale = _scale;
        }
    }
}