using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Patrol;
using Zenject;

namespace Game.Scripts.Entities.Platform
{
    public class Platform : ITickable
    {
        private readonly IEntity _entity;
        private readonly PlatformView _view;

        public Platform(IEntity entity, PlatformView view)
        {
            _entity = entity;
            _view = view;
        }

        public void Tick()
        {
            // var moveComponent = _entity.Get<IMoveComponent>();
            // var patrolComponent = _entity.Get<IPatrolable>();
            //
            // moveComponent.Move(patrolComponent.Direction);
            //
            // if (patrolComponent.IsNear)
            // {
            //     patrolComponent.MoveNext();
            // }
        }
    }
}