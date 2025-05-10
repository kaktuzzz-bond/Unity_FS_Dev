using Modules.Conditions;
using UnityEngine;

namespace Game.Scripts.Game.Core.Movement
{
    public interface IMoveComponent: ICompositeCondition
    {
        public Vector3 GetDirection { get; }

        void MoveX(float xDirection);

        void Move(Vector3 direction);
    }
}