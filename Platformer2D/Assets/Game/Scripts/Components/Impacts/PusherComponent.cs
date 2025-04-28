using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Jump;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherComponent : IInitializable, IPusher
    {
        private readonly PushSettings _settings;
        private readonly ICondition _condition;
        private readonly ICooldownTimer _timer;


        public PusherComponent(PushSettings settings)
        {
            _settings = settings;
            _condition = _settings.Condition;
            _timer = _settings.Cooldown;
        }

        public void Initialize()
        {
            AddCondition(() => !_timer.IsInProgress);
        }

        public void Push(IPushable pushable, Vector2 direction)
        {
            if (!_condition.IsValid) return;

            pushable.TakePush(direction * _settings.Force);
            _timer.Launch();
        }

        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);
    }
}