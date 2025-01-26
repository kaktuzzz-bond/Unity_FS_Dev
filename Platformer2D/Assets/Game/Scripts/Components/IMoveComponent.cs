using UnityEngine;

namespace Game.Scripts.Components
{
    public interface IMoveComponent
    {
        void Move(Vector3 direction);
    }
}