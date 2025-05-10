using System;
using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using Game.Scripts.GameSystem.Audio;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Lava
{
    public class Lava : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly AudioProvider _audioProvider;


        public Lava(IEntity entity, AudioProvider audioProvider)
        {
            _entity = entity;
            _audioProvider = audioProvider;
        }

        public void Initialize()
        {
            // _entity.Get<ITriggerObserver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            // if (!other.TryGetComponent<IDamagableBody>(out var target)) return;
            //
            // _entity.Get<IAttackComponent>().Attack(target);
            // _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Lava));
        }

        public void Dispose()
        {
            // _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}