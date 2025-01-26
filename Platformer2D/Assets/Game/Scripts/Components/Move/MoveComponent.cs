using Game.Scripts.Components.Flip;
using UnityEngine;

namespace Game.Scripts.Components.Move
{
    public class MoveComponent : IMoveComponent
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly IFlipComponent _flipComponent;


        public MoveComponent(Rigidbody2D rigidbody, float speed, IFlipComponent flipComponent)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _flipComponent = flipComponent;
        }

        public void Move(Vector3 direction)
        {
            _flipComponent.LookTowards(direction);
            _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        }
    }
}