using UnityEngine;

namespace Modules.Spaceships.Movement
{
    public interface IMoveService
    {
        Vector2 TargetPosition { get; }
        void Move(Vector2 direction);
    }
}