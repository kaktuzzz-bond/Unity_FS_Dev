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
        [field: SerializeField, Min(0)]
        public float Force { get; private set; } = 2;

        [SerializeField, Min(0)]
        private float cooldown = 2;

        private ICooldownTimer _pushTimer;

        private ICondition _condition;

        public ICooldownTimer Cooldown => _pushTimer ?? new CooldownTimer(cooldown);
        public ICondition Condition => _condition ?? new CompositeCondition();
    }
}