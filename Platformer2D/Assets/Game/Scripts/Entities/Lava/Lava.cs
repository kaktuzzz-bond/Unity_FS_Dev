using System;
using Game.Scripts.Audio;
using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Lava
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
            _entity.Get<ITriggerObserver>().OnTriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            Debug.Log($"Catch {other.name}");
            
            if (!other.TryGetComponent<IDamagableBody>(out var target)) return;

            Debug.Log($"damagable body {other.name}");
            _entity.Get<IAttackable>().Attack(target);
            _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Lava));
        }

        public void Dispose()
        {
            _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}