using System;
using System.Linq;
using Game.Scripts.Audio;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Vfx;
using Game.Scripts.Death;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Player
{
    public class Player : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IEntity _entity;
        private readonly PlayerView _view;
        private readonly AudioProvider _audioProvider;

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
            _playerInput.OnPush += Push;
            _playerInput.OnToss += Toss;
            _entity.Get<IDamagableBody>().OnDamageTaken += TakeDamage;
            // _entity.Get<IPushableBody>().OnImpacted += TakeImpact;
            //

            var healthComponent = _entity.Get<IDamagable>();
            var groundSensor = _entity.Get<IGroundRaycastSensor>();
            var jumpComponent = _entity.Get<ICharacterJumper>();
            var moveComponent = _entity.Get<ICharacterMover>();
            var pusher = _entity.Get<ICharacterPusher>(ImpactKeys.Push);
            var tosser = _entity.Get<ICharacterPusher>(ImpactKeys.Toss);

            jumpComponent.AddCondition(() => healthComponent.IsAlive);
            jumpComponent.AddCondition(() => groundSensor.IsGrounded);

            moveComponent.AddCondition(() => healthComponent.IsAlive);

            pusher.AddCondition(() => healthComponent.IsAlive);

            tosser.AddCondition(() => healthComponent.IsAlive);
            tosser.AddCondition(() => groundSensor.IsGrounded);
        }
        
        private void Move(Vector3 direction)
        {
            if (Mathf.Approximately(direction.x, 0f)) return;

            _entity.Get<ICharacterMover>().MoveX(direction.x);
        }
        
        private void Jump()
        {
            var jumper = _entity.Get<ICharacterJumper>();

            jumper.Jump(() => _entity.Get<IAudioComponent>()
                                     .Play(_audioProvider
                                         .GetClip(SoundKey.Jump)));
        }


        private void Push()
        {
            Impact(ImpactKeys.Push, _entity.Get<IMovable>().GetDirection, _view.PlayPush);
        }

        private void Toss()
        {
            Impact(ImpactKeys.Toss, Vector2.up, _view.PlayToss);
        }

      

        private void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IDamagable>();

            healthComponent.TakeDamage(damage);

            _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.TakeDamage));

            _view.ShowTakenDamage(healthComponent.HealthLevel);

            _entity.Get<ColorBlinkEffect>()
                   .Play(() =>
                   {
                       if (!healthComponent.IsAlive)
                           _entity.Get<IMortal>().Die();
                   });
        }

        private void TakeImpact(Vector3 force)
        {
            // _entity.Get<IPushable>().TakePush(force);
        }

        private void Impact(string id, Vector2 forceDirection, Action callback)
        {
            var pusher = _entity.Get<ICharacterPusher>(id);

            if (!pusher.IsValid) return;

            var bodies = _entity
                         .Get<IEntityRaycastSensor>()
                         .Scan<IPushableBody>(_entity.Get<IMovable>().GetDirection)
                         .ToHashSet();

            if (bodies.Any())
            {
                pusher.Push(bodies, forceDirection);
            }
            else
            {
                pusher.Push();
            }

            callback?.Invoke();
        }
        
        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
            _playerInput.OnPush -= Push;
            _playerInput.OnToss -= Toss;
            _entity.Get<IDamagableBody>().OnDamageTaken -= TakeDamage;
            // _entity.Get<IPushableBody>().OnImpacted -= TakeImpact;
        }
    }
}