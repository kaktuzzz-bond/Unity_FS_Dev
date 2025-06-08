using Modules;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.Entities
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
            _entity.Get<IPatrolComponent>().AddCondition(() => _isPatrol);
            _isPatrol = true;
        }
    }
}