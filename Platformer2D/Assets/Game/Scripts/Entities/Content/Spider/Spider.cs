using System;
using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Game.Entities
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
            _entity.Get<IEntityProxy>().OnTriggerEnter += OnTriggerEnter;
            _entity.Get<IPushable>().OnForceAdded += OnForceAdded;

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
        }


        private void OnForceAdded()
        {
            _entity.Get<IPatrolComponent>().Pause();
        }

        private void OnTriggerEnter(IEntity entity)
        {
            if (!entity.TryGet<IHealthComponent>(out var healthComponent)) return;

            _entity.Get<IAttackComponent>().Attack(healthComponent);

            if (!entity.TryGet<IPushable>(out var pushable)) return;

            _entity.Get<IPushComponent>().Push(pushable);
        }

        [Button]
        private void OnTriggerEnter(Collider2D other)
        {
        }

        public void Dispose()
        {
            _entity.Get<IEntityProxy>().OnTriggerEnter -= OnTriggerEnter;
            _entity.Get<IPushable>().OnForceAdded -= OnForceAdded;
        }
    }
}