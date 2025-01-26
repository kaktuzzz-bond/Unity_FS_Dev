using UnityEngine;

namespace Game.Scripts.Components.Move
{
    public interface IMoveComponent
    {
        void Move(Vector3 direction);
    }
}