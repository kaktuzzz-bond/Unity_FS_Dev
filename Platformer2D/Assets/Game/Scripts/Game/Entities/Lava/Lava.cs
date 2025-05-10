using System;
using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.MonoComponents;
using Modules.Entity;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Lava
{
    public class Lava : IInitializable, IDisposable
    {
        private readonly IEntity _entity;


        public Lava(IEntity entity)
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
            _entity.Get<LavaView>().PlayLava();
        }

        public void Dispose()
        {
            _entity.Get<ITriggerReceiver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}