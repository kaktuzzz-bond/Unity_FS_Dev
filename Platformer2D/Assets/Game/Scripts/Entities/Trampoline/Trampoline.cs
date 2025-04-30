using System;
using Game.Scripts.Audio;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trampoline
{
    public class Trampoline : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly TrampolineView _view;
        private readonly AudioProvider _audioProvider;

        public Trampoline(IEntity entity, TrampolineView view, AudioProvider audioProvider)
        {
            _entity = entity;
            _view = view;
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