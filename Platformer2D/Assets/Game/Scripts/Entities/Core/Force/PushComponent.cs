using System;
using System.Collections.Generic;
using System.Linq;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    [Serializable]
    public class PushComponent : IPushComponent, ICompositeCondition, IInitializable
    {
        [SerializeField]
        public Transform origin;

        [SerializeField]
        public Transform pushPoint;

        [SerializeField]
        public Vector2 forceDirection = Vector2.one;

        [SerializeField]
        public float pushForce = 1f;

        [SerializeField]
        private float cooldownTime = -1;

        [SerializeField]
        private EntitySensorComponent entitySensor;

        public bool IsValid => _condition.IsValid;

        private ICompositeCondition _condition = new CompositeCondition();
        private ICooldownTimer _cooldown;

        private bool IgnoreCooldown => cooldownTime < 0;
        private Vector2 Force => forceDirection.normalized * pushForce;

        public void Initialize()
        {
            AddCooldown();
        }


        public void Push(IPushable pushable)
        {
            pushable.AddForce(Force);
        }

        public bool Push()
        {
            if (!IsValid) return false;

            var direction = new Vector2(pushPoint.position.x - origin.position.x, 0f);

            var entities = entitySensor
                           .Scan<IEntityProxy>()
                           .Select(x => x.Entity)
                           .ToHashSet();

            foreach (var entity in entities)
            {
                if (!entity.TryGet<IPushable>(out var pushable)) continue;

                pushable.AddForce(Force);
            }

            if (!IgnoreCooldown)
                _cooldown.Launch();

            return true;
        }


        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _condition.RemoveCondition(condition);


        private void AddCooldown()
        {
            if (IgnoreCooldown) return;

            _cooldown = new CooldownTimer(cooldownTime);

            AddCondition(() => !_cooldown.IsInProgress);
        }
    }
}