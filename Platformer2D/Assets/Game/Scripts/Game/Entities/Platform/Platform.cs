using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Patrol;
using Modules.Entity;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.Scripts.Game.Entities.Platform
{
    public class Platform : IInitializable
    {
        private readonly IEntity _entity;

        [ShowInInspector, HideInEditorMode]
        private bool _isPatrol;

        public Platform(IEntity entity)
        {
            _entity = entity;
        }


        public void Initialize()
        {
            _entity.Get<IMoveComponent>().AddCondition(() => _isPatrol);
            _isPatrol = true;
        }
    }
}