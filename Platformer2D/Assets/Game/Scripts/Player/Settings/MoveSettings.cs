using System;
using Game.Scripts.Components.Conditions;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class MoveSettings
    {
        [field: SerializeField, Min(0)]
        public float MoveSpeed { get; private set; } = 6;
        
        [field: SerializeField, Min(0)]
        public float Drag { get; private set; } = 1;

        [field: SerializeField]
        public bool IsFlippable { get; private set; } = true;

        private ICondition _condition;
        public ICondition Condition => _condition ?? new CompositeCondition();
    }
}