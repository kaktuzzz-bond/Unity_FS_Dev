using System;
using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Game.Scripts.Entities.Trap
{
    public class Trap : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly TrapView _view;
        
        public Trap(IEntity entity, TrapView view)
        {
            _entity = entity;
            _view = view;
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
        
            KillEntity();
        }
        
        private void TakeDamage(int damage)
        {
            // var healthComponent = _entity.Get<IHealthComponent>();
            //
            // healthComponent.TakeDamage(damage);
            // _view.ShowTakenDamage(healthComponent.Health);
        }
        
        private void TakeImpact(Vector3 force)
        {
            _entity.Get<IPushable>().TakePush(force);
        }
        
        private void KillEntity()
        {
            // var healthComponent = _entity.Get<IHealthComponent>();
            //
            // healthComponent.Kill();
            // _view.ShowTakenDamage(healthComponent.Health);
        }
        
        public void Dispose()
        {
            _entity.Get<IDamagableBody>().OnDamageTaken -= TakeDamage;
            _entity.Get<IPushableBody>().OnImpacted -= TakeImpact;
            _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}