using System;
using Modules;
using Zenject;

namespace Game.Entities
{
    public class Player : IInitializable, ITossAdapter, IPushAdapter
    {
        public event Action OnPush;
        public event Action OnToss;

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

            _entity.Get<PushComponent>(typeof(IPushAdapter))
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<PushComponent>(typeof(ITossAdapter))
                   .AddCondition(() => _entity.Get<IHealthComponent>().IsAlive);

            _entity.Get<PushComponent>(typeof(ITossAdapter))
                   .AddCondition(() => _entity.Get<IGroundSensor>().IsGrounded);
        }


        public void Push()
        {
            _entity.Get<IEntitySensorComponent>()
                   .ScanAndRun<IPushableComponent>(_entity.Get<PushComponent>(typeof(IPushAdapter)).Push);

            OnPush?.Invoke();
        }

        public void Toss()
        {
            _entity.Get<IEntitySensorComponent>()
                   .ScanAndRun<IPushableComponent>(_entity.Get<PushComponent>(typeof(ITossAdapter)).Push);

            OnToss?.Invoke();
        }
    }
}