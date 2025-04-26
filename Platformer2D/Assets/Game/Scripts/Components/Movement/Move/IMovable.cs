using UnityEngine;

namespace Game.Scripts.Components.Movement.Move
{
    public interface IMovable
    {
        void Move(Vector3 direction);
    }
}