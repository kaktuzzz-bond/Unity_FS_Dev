using UnityEngine;

namespace Game.Scripts.Components.Movement
{
    public interface IMovable
    {
        public Vector3 GetDirection { get; }
        void MoveX(float xDirection);

        void Move(Vector3 direction);

        void ForceMoveX(float value);

        void ForceMove(Vector2 force);
    }
}