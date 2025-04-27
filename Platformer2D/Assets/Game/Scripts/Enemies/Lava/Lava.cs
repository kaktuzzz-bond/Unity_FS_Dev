using System;
using Game.Scripts.Audio;
using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Lava
{
    public class Lava : IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly LavaView _view;
        private readonly AudioProvider _audioProvider;


        public Lava(IEntity entity, LavaView view, AudioProvider audioProvider)
        {
            _entity = entity;
            _view = view;
            _audioProvider = audioProvider;
        }

        public void Initialize()
        {
            _entity.Get<ITriggerSensor>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            if (!other.TryGetComponent<IDamagable>(out var target)) return;

            _entity.Get<IAttackable>().Attack(target);
            _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Lava));
        }

        public void Dispose()
        {
            _entity.Get<ITriggerSensor>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}