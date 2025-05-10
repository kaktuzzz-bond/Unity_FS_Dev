using System;
using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Impacts.Pushable;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trap
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
            // _entity.Get<IDamagableBody>().OnDamageTaken += TakeDamage;
            // _entity.Get<IPushableBody>().OnImpacted += TakeImpact;
            // _entity.Get<ITriggerObserver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            // if (!other.TryGetComponent<IDamagableBody>(out var target)) return;
            //
            // _entity.Get<IAttackComponent>().Attack(target);
            //
            // _entity.Get<IDeathComponent>().Die();
        }


        private void TakeDamage(int damage)
        {
            // var healthComponent = _entity.Get<IHealthComponent>();
            //
            // healthComponent.TakeDamage(damage);
            //
            // if (!healthComponent.IsAlive)
            // {
            //     _entity.Get<IDeathComponent>().Die();
            // }
        }

        private void TakeImpact(Vector3 force)
        {
            // _entity.Get<IPushable>().TakePush(force);
        }


        public void Dispose()
        {
            // _entity.Get<IDamagableBody>().OnDamageTaken -= TakeDamage;
            // _entity.Get<IPushableBody>().OnImpacted -= TakeImpact;
            // _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}