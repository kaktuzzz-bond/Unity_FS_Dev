using System;
using Modules.Conditions;
using Modules.Cooldown;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Core.Jump
{
    [Serializable]
    public class JumpComponent : IJumpComponent, IInitializable, ITickable
    {
        [SerializeField]
        private Rigidbody2D rigidbody;

        [SerializeField, Min(0)]
        private float jumpHeight;

        [SerializeField, Min(0)]
        private float fallGravityScale;

        [SerializeField]
        private float cooldownTime = -1;

        private float _defaultGravityScale;
        private float _jumpForce;

        private ICooldownTimer _cooldown;
        
        private readonly CompositeCondition _condition = new();
        private bool IgnoreCooldown => cooldownTime < 0;

        public bool IsValid => _condition.IsValid;

        public void Initialize()
        {
            _defaultGravityScale = rigidbody.gravityScale;

            _jumpForce = Mathf.Sqrt(jumpHeight *
                                    Mathf.Abs(Physics2D.gravity.y * _defaultGravityScale * 2)) *
                         rigidbody.mass;

            AddCooldown();
        }


        public void Tick()
        {
            rigidbody.gravityScale = rigidbody.velocity.y > 0 ? _defaultGravityScale : fallGravityScale;
        }


        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _condition.RemoveCondition(condition);

        public bool Jump() => Jump(Vector2.up, _jumpForce);

        private bool Jump(Vector2 direction, float force)
        {
            if (!_condition.IsValid)
            {
                Debug.Log("Cannot JUMP because of conditions");

                return false;
            }

            rigidbody.AddForce(direction * force, ForceMode2D.Impulse);

            if (!IgnoreCooldown)
                _cooldown.Launch();

            return true;
        }


        private void AddCooldown()
        {
            if (IgnoreCooldown) return;

            _cooldown = new CooldownTimer(cooldownTime);

            AddCondition(() => !_cooldown.IsInProgress);
        }
    }
}