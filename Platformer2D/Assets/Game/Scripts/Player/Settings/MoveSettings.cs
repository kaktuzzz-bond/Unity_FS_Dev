using System;
using Game.Scripts.Components.Conditions;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class MoveSettings
    {
        [SerializeField, Min(0)]
        private float moveSpeed = 5;

        public float MoveSpeed => moveSpeed;

        [SerializeField, Min(0)]
        private float drag = 5;

        public float Drag => drag;

        private ICondition _condition;
        public ICondition Condition => _condition ?? new CompositeCondition();
    }
}