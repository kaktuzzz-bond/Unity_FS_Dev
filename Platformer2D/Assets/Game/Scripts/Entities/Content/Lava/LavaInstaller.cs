using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class LavaInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private LavaView view;

        [SerializeField, BoxGroup("Attack", ShowLabel = false)]
        private AttackComponent attackComponent;
        
        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private EntityProxy entityProxy;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.Bind<LavaView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Lava>()
                     .AsSingle();

            Container.BindInterfacesTo<AttackComponent>()
                     .FromInstance(attackComponent)
                     .AsSingle();

            Container.BindInterfacesTo<EntityProxy>()
                     .FromInstance(entityProxy)
                     .AsSingle();
        }
    }
}