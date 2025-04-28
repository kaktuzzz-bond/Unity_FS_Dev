using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Jump;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class JumpSettings
    {
        [field: SerializeField, Min(0)]
        public float JumpHeight { get; private set; } = 5;

        [field: SerializeField, Min(0)]
        public float FallGravityScale { get; private set; } = 1;

        [SerializeField, Min(0)]
        private float jumpCooldown = 1;

        private ICooldownTimer _timer;

        private ICondition _condition;
        public ICooldownTimer Cooldown => _timer ?? new CooldownTimer(jumpCooldown);
        public ICondition Condition => _condition ?? new CompositeCondition();
    }
}