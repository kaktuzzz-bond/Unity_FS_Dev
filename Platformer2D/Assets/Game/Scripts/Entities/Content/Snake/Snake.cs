using System;
using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class Snake: IInitializable, IDisposable
    {
        private readonly IEntity _entity;

        public Snake(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter += OnTriggerEnter;
            _entity.Get<IPushable>().OnForceAdded += _entity.Get<IPatrolComponent>().Pause;

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
        }


        [Button]
        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IEntityProxy>(out var proxy)) return;

            if (!proxy.Entity.TryGet<IDamagable>(out var damagable)) return;

            _entity.Get<IAttackComponent>().Attack(damagable);

            if (!proxy.Entity.TryGet<IPushable>(out var pushable)) return;
            
            _entity.Get<IPushComponent>().Push(pushable);
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
            _entity.Get<IPushable>().OnForceAdded -= _entity.Get<IPatrolComponent>().Pause;
        }
    }
}