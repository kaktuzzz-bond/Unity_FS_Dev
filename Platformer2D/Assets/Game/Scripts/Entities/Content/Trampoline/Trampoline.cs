using System;
using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class Trampoline : IInitializable, IDisposable
    {
        private readonly IEntity _entity;

        public Trampoline(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IEntityProxy>(out var proxy)) return;
            
            if (!proxy.Entity.TryGet<IPushable>(out var target)) return;

            _entity.Get<IPushComponent>().Push(target);

            _entity.Get<TrampolineView>().PlayJump();
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}