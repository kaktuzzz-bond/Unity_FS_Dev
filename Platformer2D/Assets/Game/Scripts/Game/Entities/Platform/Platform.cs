using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Patrol;
using Zenject;

namespace Game.Scripts.Game.Entities.Platform
{
    public class Platform : ITickable
    {
        private readonly IEntity _entity;
      

        public Platform(IEntity entity)
        {
            _entity = entity;
        }

        public void Tick()
        {
            var moveComponent = _entity.Get<IMoveComponent>();
            var patrolComponent = _entity.Get<IPatrolable>();
            
            moveComponent.Move(patrolComponent.Direction);
            
            if (patrolComponent.IsNear)
            {
                patrolComponent.MoveNext();
            }
        }
    }
}