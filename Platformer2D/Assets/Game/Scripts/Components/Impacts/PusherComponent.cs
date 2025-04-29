using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Jump;
using Game.Scripts.Player.Settings;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherComponent : IInitializable, IPusherComponent
    {
        private readonly IPusher _pusher;
        private readonly PushSettings _settings;

        [ShowInInspector]
        private readonly ICondition _condition;

        [ShowInInspector]
        private readonly ICooldownTimer _timer;

        [ShowInInspector]
        public bool IsValid => _condition.IsValid;

        public PusherComponent(IPusher pusher, PushSettings settings)
        {
            _pusher = pusher;
            _settings = settings;
            _condition = _settings.Condition;
            _timer = _settings.Cooldown;
        }

        public void Initialize() => AddCondition(() => !_timer.IsInProgress);

        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _condition.RemoveCondition(condition);

        public void Push(IPushable pushable, Vector2 direction)
        {
            if (!IsValid) return;
            _pusher.Push(pushable, direction * _settings.Force);
            _timer.Launch();
        }
    }
}