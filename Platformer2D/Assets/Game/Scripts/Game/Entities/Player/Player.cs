using System;
using System.Linq;
using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Conditions;
using Game.Scripts.Game.Core.Cooldown;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Impacts;
using Game.Scripts.Game.Core.Impacts.Pushable;
using Game.Scripts.Game.Core.Impacts.Pusher;
using Game.Scripts.Game.Core.Jump;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Sensors.EntityRaycast;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.Game.Core.Vfx;
using Game.Scripts.GameSystem.Audio;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class Player : IPlayer, IInitializable, IDisposable
    {
        private readonly IEntity _entity;
        private readonly PlayerView _view;
        private readonly AudioProvider _audioProvider;

        public Player(IEntity entity, PlayerView view, AudioProvider audioProvider)
        {
            _entity = entity;
            _view = view;
            _audioProvider = audioProvider;
        }


        public void Initialize()
        {
            _entity.Get<IJumpComponent>()
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);
            _entity.Get<IJumpComponent>()
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<IMoveComponent>()
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);
            // var healthComponent = _entity.Get<IHealthComponent>();
            // var groundSensor = _entity.Get<IGroundRaycastSensor>();

            // var moveComponent = _entity.Get<ICharacterMover>();
            // var pusher = _entity.Get<ICharacterPusher>(ImpactKeys.Push);
            // var tosser = _entity.Get<ICharacterPusher>(ImpactKeys.Toss);
            
            // pusher.AddCondition(() => healthComponent.IsAlive);
            //
            // tosser.AddCondition(() => healthComponent.IsAlive);
            // tosser.AddCondition(() => groundSensor.IsGrounded);
        }


        public void Move(Vector3 direction)
        {
            Debug.Log($"Move: {direction}");
            _entity.Get<IMoveComponent>().MoveX(direction.x);
        }

        public void Jump()
        {
            if (!_entity.Get<IJumpComponent>().Jump()) return;

            var clip = _audioProvider.GetClip(SoundKey.Jump);
            _entity.Get<IAudioComponent>().Play(clip);
        }


        public void Push()
        {
            Debug.Log($"Push");
            // Impact(ImpactKeys.Push, () =>
            // {
            //     _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Push));
            //     _view.PlayPush();
            // });
        }

        public void Toss()
        {
            Debug.Log($"Toss");
            // Impact(ImpactKeys.Toss, () =>
            // {
            //     _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.Toss));
            //     _view.PlayToss();
            // });
        }

        public void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IHealthComponent>();

            healthComponent.TakeDamage(damage);

            _entity.Get<IAudioComponent>().Play(_audioProvider.GetClip(SoundKey.TakeDamage));

            _view.ShowTakenDamage(healthComponent.HealthLevel);

            _entity.Get<IVisualFX>()
                   .Play(() =>
                   {
                       if (!healthComponent.IsAlive)
                           _entity.Get<PlayerView>().PlayDeath();
                   });
        }

        private void TakeImpact(Vector3 force)
        {
            // _entity.Get<IPushable>().TakePush(force);
        }

        private void Impact(string id, Action callback)
        {
            // var pusher = _entity.Get<ICharacterPusher>(id);
            //
            // if (!pusher.IsValid) return;
            //
            // var forceDirection = _entity.Get<DirectionData>(id).NormalizedDirection;
            // var bodyDirection = _entity.Get<IMoveComponent>().GetDirection;
            // forceDirection.x *= bodyDirection.x;
            //
            // var bodies = _entity
            //              .Get<IEntityRaycastSensor>()
            //              .Scan<IPushableBody>(bodyDirection)
            //              .ToHashSet();
            //
            // if (bodies.Any())
            // {
            //     pusher.Push(bodies, forceDirection);
            // }
            // else
            // {
            //     pusher.Push();
            // }
            //
            // callback?.Invoke();
        }

        public void Dispose()
        {
            _entity.Get<IHealthComponent>().OnHealthChanged -= _view.ShowTakenDamage;
        }
    }
}