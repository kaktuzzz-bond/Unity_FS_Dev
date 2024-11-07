using UnityEngine;

namespace Modules.Spaceships.Components
{
    public class MoveComponent
    {
        public Vector2 CurrentPosition { get; private set; }

        private readonly float _speed;

        public MoveComponent(float speed)
        {
            _speed = speed;
        }

        public void Move(Transform target, Vector2 velocity, float deltaTime)
        {
            CurrentPosition += velocity * _speed * deltaTime;
            target.position = CurrentPosition;
        }
    }
}