using Modules.Conditions;
using UnityEngine;

namespace Game.Scripts.Game.Core.Movement
{
    public interface IMoveComponent : ICompositeCondition
    {
        void Move(Vector2 direction);
    }
}