using System;
using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Impacts.Pushable;
using Game.Scripts.Game.Core.Impacts.Pusher;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using Game.Scripts.GameSystem.Audio;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trampoline
{
    public class Trampoline : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly AudioProvider _audioProvider;

        public Trampoline(IEntity entity,  AudioProvider audioProvider)
        {
            _entity = entity;
            _audioProvider = audioProvider;
        }

        public void Initialize()
        {
            _entity.Get<ITriggerObserver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IPushableBody>(out var target)) return;

            _entity.Get<IPusher>().Push(target, Vector2.up);
            _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Trampoline));
        }

        public void Dispose()
        {
            _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}