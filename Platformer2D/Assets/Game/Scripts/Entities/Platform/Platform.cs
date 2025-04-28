using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Movement.Move;
using UnityEngine;
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
            var moveComponent = _entity.Get<IMoveComponent>();
            var patrolComponent = _entity.Get<IPatrolComponent>();

            moveComponent.Move(patrolComponent.Direction);

            if (patrolComponent.IsNear)
            {
                patrolComponent.MoveNext();
            }
        }
    }
}