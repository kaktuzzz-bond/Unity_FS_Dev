using System;
using Game.Scripts.Game.Core.Force;
using Game.Scripts.Game.Core.Sensors.TriggerSensor;
using Modules.Entity;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trampoline
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
            if (!other.TryGetComponent<IForceComponent>(out var target)) return;

            target.AddForce(_entity.Get<ForceData>().GetForce());

            _entity.Get<TrampolineView>().PlayJump();
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}