using System;
using Modules.Entity;
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
            if (!other.TryGetComponent<IPushable>(out var target)) return;

            target.AddForce(_entity.Get<ForceData>().GetForce());

            _entity.Get<TrampolineView>().PlayJump();
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}