using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
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
            _entity.Get<ITriggerReceiver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IDamagable>(out var target)) return;

            _entity.Get<IAttackComponent>().Attack(target);

            _entity.Get<IHealthComponent>().TakeDamage(int.MaxValue);
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}