using Modules;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class Player : IInitializable
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

            _entity.Get<PushComponent>(PushKey.Push)
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<PushComponent>(PushKey.Toss)
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<PushComponent>(PushKey.Toss)
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
            if (!_entity.Get<PushComponent>(PushKey.Push).Push())
                return;

            _entity.Get<PlayerView>()
                   .PlayPush();
        }

        public void Toss()
        {
            if (!_entity.Get<PushComponent>(PushKey.Toss).Push())
                return;

            _entity.Get<PlayerView>()
                   .PlayToss();
        }
    }
}