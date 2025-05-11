using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Jump;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Sensors.EntityRaycast;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.GameSystem.Audio;
using Modules.Entity;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class Player : IPlayer, IInitializable, IDisposable
    {
        private readonly IEntity _entity;
       

        public Player(IEntity entity)
        {
            _entity = entity;
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


        public void Move(Vector2 direction)
        {
            _entity.Get<IMoveComponent>()
                   .Move(direction);
        }

        public void Jump()
        {
            if (_entity.Get<IJumpComponent>()
                       .Jump())
            {
                _entity.Get<PlayerView>().PlayJump();
            }
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
        }
    }
}