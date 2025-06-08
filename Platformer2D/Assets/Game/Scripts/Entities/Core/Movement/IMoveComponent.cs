using Modules.Conditions;
using UnityEngine;

namespace Game.Entities
{
    public interface IMoveComponent : ICompositeCondition
    {
        Vector2 GetDirection { get; }

        void Move(Vector2 direction);
    }
}