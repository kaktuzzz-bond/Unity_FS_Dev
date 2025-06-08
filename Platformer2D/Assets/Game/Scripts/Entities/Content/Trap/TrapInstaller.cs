using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Entities
{
    public class TrapInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private TrapView view;

        [SerializeField, BoxGroup("Health", ShowLabel = false)]
        private HealthComponent healthComponent;

        [SerializeField, BoxGroup("Attack", ShowLabel = false)]
        private AttackComponent attackComponent;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private EntityProxy entityProxy;
        
        [FormerlySerializedAs("forceComponent")]
        [SerializeField, BoxGroup("Force", ShowLabel = false)]
        private PushableComponent pushableComponent;
        

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Trap>()
                     .AsSingle();

            Container.BindInterfacesTo<HealthComponent>()
                     .FromInstance(healthComponent)
                     .AsSingle();

            Container.BindInterfacesTo<AttackComponent>()
                     .FromInstance(attackComponent)
                     .AsSingle();

            Container.BindInterfacesTo<EntityProxy>()
                     .FromInstance(entityProxy)
                     .AsSingle();

            Container.BindInterfacesTo<PushableComponent>()
                     .FromInstance(pushableComponent)
                     .AsSingle();

            Container.Bind<TrapView>()
                     .FromInstance(view)
                     .AsSingle();
        }
    }
}