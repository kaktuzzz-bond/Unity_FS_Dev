using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class JumpComponent : IJumpComponent, IInitializable, ITickable

    {
        private readonly Rigidbody2D _rb;

        private readonly JumpSettings _jumpSettings;

        private readonly ICondition _condition;
        private readonly ICooldownTimer _timer;

        private float _defaultGravityScale;

        private float JumpForce =>
            Mathf.Sqrt(_jumpSettings.JumpHeight *
                       Mathf.Abs(Physics2D.gravity.y * _rb.gravityScale)) *
            _rb.mass;

        public JumpComponent(Rigidbody2D rb, JumpSettings jumpSettings)
        {
            _rb = rb;
            _jumpSettings = jumpSettings;
            _condition = _jumpSettings.Condition;
            _timer = _jumpSettings.Cooldown;

            _defaultGravityScale = _rb.gravityScale;
        }

        public void Initialize()
        {
            AddCondition(() => !_timer.IsInProgress);
            _defaultGravityScale = _rb.gravityScale;
        }

        public void Tick()
        {
            _rb.gravityScale = _rb.velocity.y > 0 ? _defaultGravityScale : _jumpSettings.FallGravityScale;
        }

        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public bool TryJump()
        {
            if (!_condition.IsValid) return false;

            Jump();

            return true;
        }

        private void Jump()
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            _timer.Launch();
        }
    }
}