using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Jump;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Sensors.EntityRaycast;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Modules.Entity;
using Unity.VisualScripting;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Game.Scripts.Game.Entities.Player
{
    public class Player : IPlayer, IInitializable
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

            _entity.Get<EntitySensor>(PushKey.Push)
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<EntitySensor>(PushKey.Toss)
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<EntitySensor>(PushKey.Toss)
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);
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
                _entity.Get<PlayerView>()
                       .PlayJump();
            }
        }


        public void Push()
        {
            if (!_entity.Get<EntitySensor>(PushKey.Push)
                        .Push(_entity.Get<IMoveComponent>().GetDirection))
                return;

            _entity.Get<PlayerView>()
                   .PlayPush();
        }

        public void Toss()
        {
            if (!_entity.Get<EntitySensor>(PushKey.Toss)
                        .Push(_entity.Get<IMoveComponent>().GetDirection))
                return;

            _entity.Get<PlayerView>()
                   .PlayToss();
        }
    }
}