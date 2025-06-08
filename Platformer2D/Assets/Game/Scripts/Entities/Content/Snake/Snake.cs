using System;
using Modules.Entity;
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
            _entity.Get<IForceComponent>().OnForceAdded += _entity.Get<IPatrolComponent>().Pause;

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
        }


        [Button]
        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IDamagable>(out var damagable)) return;

            _entity.Get<IAttackComponent>().Attack(damagable);

            if (!other.TryGetComponent<IPushable>(out var body)) return;

            body.AddForce(_entity.Get<ForceData>().GetForce(), _entity.Get<IForceComponent>().Position);
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
            _entity.Get<IForceComponent>().OnForceAdded -= _entity.Get<IPatrolComponent>().Pause;
        }
    }
}