using System;
using System.Linq;
using Game.GameSystem;
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
            _entity.Get<ICharacterController>().SetEntity(_entity);

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
            if (ScanAndPush(id: typeof(IPushAdapter)))
            {
                OnPush?.Invoke();
            }
        }

        public void Toss()
        {
            if (ScanAndPush(id: typeof(ITossAdapter)))
            {
                OnToss?.Invoke();
            }
        }

        private bool ScanAndPush(Type id)
        {
            var components = _entity.Get<IEntitySensorComponent>()
                                    .ScanFor<IPushableComponent>()
                                    .ToArray();

            return _entity.Get<PushComponent>(id).Push(components);
        }
    }
}