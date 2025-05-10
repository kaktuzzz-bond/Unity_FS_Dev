using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Impacts.Pushable;
using Game.Scripts.Game.Core.Impacts.Pusher;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Patrol;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using Game.Scripts.Game.Core.Vfx;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace Game.Scripts.Game.Entities.Spider
{
    public class Spider : IInitializable, IFixedTickable, IDisposable
    {
       
        private readonly IEntity _entity;

        [ShowInInspector]
        private bool _canMove = true;

        private const float WaitAfterImpact = 1f;
        private readonly CancellationTokenSource _cts = new();
        
        public Spider(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            // _entity.Get<IDamagableBody>().OnDamageTaken += TakeDamage;
            // _entity.Get<IPushableBody>().OnImpacted += TakeImpact;
            // _entity.Get<ITriggerObserver>().OnTriggerEnter += OnTriggerEnter;
        }

        public void FixedTick()
        {
          
            // if (!_canMove || !_entity.Get<IGroundRaycastSensor>().IsGrounded) return;
            //
            // var moveComponent = _entity.Get<IMoveComponent>();
            // var patrolComponent = _entity.Get<IPatrolable>();
            //
            // var dir = patrolComponent.Direction;
            //
            // moveComponent.Move(dir);
            //
            // if (patrolComponent.IsNear)
            // {
            //     patrolComponent.MoveNext();
            // }
        }

        [Button]
        private void TakeDamage(int damage)
        {
            // var healthComponent = _entity.Get<IHealthComponent>();
            //
            // healthComponent.TakeDamage(damage);
            //
            // _entity.Get<ColorBlinkEffect>()
            //        .Play(() =>
            //        {
            //            if (!healthComponent.IsAlive)
            //                _entity.Get<IDeathComponent>().Die();
            //        });
        }

        [Button]
        private void TakeImpact(Vector3 force)
        {
            // TakeImpactAsync(force).Forget();
        }

        private async UniTaskVoid TakeImpactAsync(Vector3 force)
        {
            // _canMove = false;
            //
            // _entity.Get<IPushable>().TakePush(force);
            // await UniTask.WaitForSeconds(WaitAfterImpact, cancellationToken: _cts.Token);
            //
            // _canMove = true;
        }

        [Button]
        private void OnTriggerEnter(Collider2D other)
        {
            // if (!other.TryGetComponent<IDamagableBody>(out var target)) return;
            //
            // _entity.Get<IAttackComponent>().Attack(target);
            //
            // if (!other.TryGetComponent<IPushableBody>(out var otherBody)) return;
            //
            // var ownBody = _entity.Get<IPushableBody>();
            //
            // var pushDirection = (otherBody.WorldPosition - ownBody.WorldPosition).x < 0f
            //     ? Vector2.left
            //     : Vector2.right;
            //
            // var pusher = _entity.Get<IPusher>();
            //
            // pusher.Push(otherBody, pushDirection);
        }

        public void Dispose()
        {
            // _entity.Get<IDamagableBody>().OnDamageTaken -= TakeDamage;
            // _entity.Get<IPushableBody>().OnImpacted -= TakeImpact;
            // _entity.Get<ITriggerObserver>().OnTriggerEnter -= OnTriggerEnter;
        }
    }
}