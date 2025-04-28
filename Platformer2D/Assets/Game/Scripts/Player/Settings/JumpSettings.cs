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
        [SerializeField, Min(0)]
        private float jumpHeight = 10;

        [SerializeField, Min(0)]
        private float fallGravityScale = 3;
        
        [SerializeField, Min(0)]
        private float jumpCooldown = 2;

        public float JumpHeight => jumpHeight;
        public float FallGravityScale => fallGravityScale;

        private ICooldownTimer _timer;

        private ICondition _condition;
        public ICooldownTimer Cooldown => _timer ?? new CooldownTimer(jumpCooldown);
        public ICondition Condition => _condition ?? new CompositeCondition();
    }
}