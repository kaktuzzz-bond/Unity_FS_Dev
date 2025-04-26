using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;

namespace Game.Scripts.Components.Jump
{
    public class Jumper : IConditionable
    {
        private readonly IJumpable _jumpable;
        private readonly CooldownTimer _timer;
        private readonly CompositeCondition _condition = new();

        public Jumper(IJumpable jumpable, CooldownTimer timer)
        {
            _jumpable = jumpable;
            _timer = timer;
            _condition.AddCondition(() => !_timer.IsInProgress);
        }

        public bool Jump()
        {
            if (!_condition.IsValid) return false;

            _jumpable.Jump();
            _timer.Launch();

            return true;
        }

        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);
    }
}