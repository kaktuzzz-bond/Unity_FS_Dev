using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Jump;
using UnityEngine;

namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class PushSettings
    {
        [field: SerializeField]
        public Vector2 DefaultDirection { get; private set; } = Vector2.up;

        [SerializeField, Min(0)]
        private float force = 2;
        
        [SerializeField, Min(0)]
        private float pushCooldown = 2;

        private ICooldownTimer _pushTimer;
       
        private ICondition _condition;
        public ICooldownTimer PushCooldown => _pushTimer ?? new CooldownTimer(pushCooldown);
        public ICondition Condition => _condition ?? new CompositeCondition();

        public Vector2 GetForce(Vector2 direction) => direction.normalized * force;
    }
}