using System;
using Game.Scripts.Audio;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Player : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IEntity _entity;
        private readonly PlayerView _view;
        private readonly AudioProvider _audioProvider;

        private CompositeCondition _jumpCondition;
        private CompositeCondition _moveCondition;
        private CooldownTimer _jumpCooldown;

        public Player(IPlayerInput playerInput, IEntity entity, PlayerView view, AudioProvider audioProvider)
        {
            _playerInput = playerInput;
            _entity = entity;
            _view = view;
            _audioProvider = audioProvider;
        }


        public void Initialize()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
            _entity.Get<IDamagableBody>().OnDamageTaken += TakeDamage;
            _entity.Get<IPushableBody>().OnImpacted += TakeImpact;

            _entity.Get<Jumper>().AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
            _entity.Get<Jumper>().AddCondition(() => _entity.Get<IGroundRaycastSensor>().IsGrounded);
            _entity.Get<Mover>().AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
        }


        [Button, HideInEditorMode]
        private void Move(Vector3 direction)
        {
            var mover = _entity.Get<Mover>();
            mover.Move(direction);
        }

        [Button, HideInEditorMode]
        private void Jump()
        {
            if (_entity.Get<Jumper>().Jump())
            {
                _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Jump));
            }
        }

        [Button, HideInEditorMode]
        public void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IHealthComponent>();

            healthComponent.TakeDamage(damage);

            _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.TakeDamage));
            _view.ShowTakenDamage(healthComponent.Health);
        }

        [Button, HideInEditorMode]
        private void TakeImpact(Vector3 force)
        {
            _entity.Get<IPushable>().TakePush(force);
        }

        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
            _entity.Get<IDamagableBody>().OnDamageTaken -= TakeDamage;
            _entity.Get<IPushableBody>().OnImpacted -= TakeImpact;
        }
    }
}