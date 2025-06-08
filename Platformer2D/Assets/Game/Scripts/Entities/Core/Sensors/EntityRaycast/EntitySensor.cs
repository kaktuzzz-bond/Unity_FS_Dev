using System;
using System.Collections.Generic;
using Modules.Conditions;
using Modules.Cooldown;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    [Serializable]
    public class EntitySensor : IEntitySensor, ICompositeCondition, IInitializable
    {
        [SerializeField]
        public Transform origin;

        [SerializeField, Min(0)]
        public float raycastDistance = 1;

        [SerializeField]
        public LayerMask layerMask;

        [SerializeField]
        public Vector2 force = Vector2.one;

        [SerializeField, Min(0)]
        public int raycastLimit = 8;

        [SerializeField]
        private float cooldownTime = -1;

        public bool IsValid => _condition.IsValid;

        private RaycastHit2D[] _hits;

        private ICompositeCondition _condition = new CompositeCondition();
        private ICooldownTimer _cooldown;

        private bool IgnoreCooldown => cooldownTime < 0;

        public void Initialize()
        {
            _hits = new RaycastHit2D[raycastLimit];

            AddCooldown();
        }

        public bool Push(Vector2 scanDirection)
        {
            if (!IsValid) return false;

            var targets = Scan<IPushable>(scanDirection);

            foreach (var target in targets)
            {
                target.AddForce(force, origin.position);
            }

            if (!IgnoreCooldown)
                _cooldown.Launch();

            return true;
        }


        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _condition.RemoveCondition(condition);

        private IEnumerable<T> Scan<T>(Vector2 direction) where T : class
        {
            Debug.DrawRay(origin.position, direction * raycastDistance, Color.red, 0.5f);

            Physics2D.queriesHitTriggers = false;

            _ = Physics2D.RaycastNonAlloc(origin.position, direction, _hits, raycastDistance, layerMask);

            var targets = new List<T>();

            foreach (var hit in _hits)
            {
                var collider = hit.collider;

                if (collider == null) continue;

                if (!collider.TryGetComponent<T>(out var target)) continue;

                targets.Add(target);
            }

            Array.Clear(_hits, 0, _hits.Length);

            return targets;
        }

        private void AddCooldown()
        {
            if (IgnoreCooldown) return;

            _cooldown = new CooldownTimer(cooldownTime);

            AddCondition(() => !_cooldown.IsInProgress);
        }
    }
}