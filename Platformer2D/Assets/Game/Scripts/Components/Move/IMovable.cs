using UnityEngine;

namespace Game.Scripts.Components.Move
{
    public interface IMovable
    {
        void Move(Vector3 direction);
    }
}