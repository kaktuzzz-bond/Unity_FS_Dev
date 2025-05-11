using System;
using System.Threading;
using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Force;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Patrol;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.Game.Core.Sensors.TriggerSensor;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Game.Scripts.Game.Entities.Spider
{
    public class Spider : IInitializable, IDisposable
    {
        private readonly IEntity _entity;

        public Spider(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter += OnTriggerEnter;
            _entity.Get<IForceComponent>().OnForceAdded += OnForceAdded;

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
        }

        private void OnForceAdded()
        {
            Debug.Log($"Spider force added");
            _entity.Get<IPatrolComponent>().Pause();
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
            _entity.Get<IForceComponent>().OnForceAdded -= OnForceAdded;
        }
    }
}