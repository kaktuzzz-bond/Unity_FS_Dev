using UnityEngine;

namespace Game.Scripts.Components.Move
{
    public class MoveComponent : IMovable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
      

        public MoveComponent(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }
        
        public void Move(Vector3 direction) => _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        
    }
}