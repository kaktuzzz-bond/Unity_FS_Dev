using System;
using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    [Serializable]
    public class PushComponent : ICompositeCondition, IInitializable
    {
        [SerializeField]
        public Transform pushPoint;

        [SerializeField]
        public Vector2 forceDirection = Vector2.one;

        [SerializeField]
        public float pushForce = 1f;

        [SerializeField]
        private float cooldownTime = -1;

        public bool IsValid => _condition.IsValid;

        [ShowInInspector, HideInEditorMode, ReadOnly]
        private ICompositeCondition _condition = new CompositeCondition();

        [ShowInInspector, HideInEditorMode, ReadOnly]
        private ICooldownTimer _cooldown;

        [ShowInInspector, HideInEditorMode, ReadOnly]
        private bool IgnoreCooldown => cooldownTime < 0f;

        public void Initialize()
        {
            AddCooldown();
        }

        public bool Push(params IPushableComponent[] pushables)
        {
            if (!IsValid)
            {
                Debug.Log("Cannot PUSH because of conditions");

                return false;
            }

            foreach (var pushable in pushables)
            {
                var sign = Mathf.Sign(pushable.GetPosition.x - pushPoint.position.x);

                var direction = new Vector2(forceDirection.x * sign, forceDirection.y);

                ApplyForce(pushable, direction, pushForce);
            }

            if (!IgnoreCooldown)
                _cooldown.Launch();

            return true;
        }


        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _condition.RemoveCondition(condition);

        private void ApplyForce(IPushableComponent pushable, Vector2 direction, float force)
        {
            var calcForce = direction.normalized * force;
            pushable.AddForce(calcForce);
        }

        private void AddCooldown()
        {
            if (IgnoreCooldown) return;

            _cooldown = new CooldownTimer(cooldownTime);

            AddCondition(() => !_cooldown.IsInProgress);
        }
    }
}