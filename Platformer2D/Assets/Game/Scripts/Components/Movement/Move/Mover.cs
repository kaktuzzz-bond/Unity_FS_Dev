using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Movement.Flip;
using UnityEngine;

namespace Game.Scripts.Components.Movement.Move
{
    public class Mover: IConditionable
    {
        private readonly IMovable _moveComponent;
        private readonly IFlippable _flipComponent;
        private readonly CompositeCondition _condition = new();

        public Mover(IMovable moveComponent, IFlippable FlipComponent)
        {
            _moveComponent = moveComponent;
            _flipComponent = FlipComponent;
        }
        public bool Move(Vector3 direction)
        {
            if (!_condition.IsValid) return false;

            _flipComponent.LookTowards(direction);
            _moveComponent.Move(direction);

            return true;
        }
        
        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

    }
}