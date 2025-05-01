using System;
using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trap
{
    public class Trap : IInitializable, IDisposable
    {
        private readonly IEntity _entity;

        public Trap(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            _entity.Get<IDamagableBody>().OnDamageTaken += TakeDamage;
            _entity.Get<IPushableBody>().OnImpacted += TakeImpact;
            _entity.Get<ITriggerObserver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IDamagableBody>(out var target)) return;

            _entity.Get<IAttackable>().Attack(target);

            _entity.Get<IMortal>().Die();
        }


        private void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IDamagable>();

            healthComponent.TakeDamage(damage);

            if (!healthComponent.IsAlive)
            {
                _entity.Get<IMortal>().Die();
            }
        }

        private void TakeImpact(Vector3 force)
        {
            _entity.Get<IPushable>().TakePush(force);
        }


        public void Dispose()
        {
            _entity.Get<IDamagableBody>().OnDamageTaken -= TakeDamage;
            _entity.Get<IPushableBody>().OnImpacted -= TakeImpact;
            _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}