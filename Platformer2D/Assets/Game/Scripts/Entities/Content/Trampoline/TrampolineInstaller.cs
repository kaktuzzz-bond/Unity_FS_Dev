using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Entities
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private TrampolineView view;

        [FormerlySerializedAs("triggerReceiver")]
        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private EntityProxy entityProxy;

        [SerializeField, BoxGroup("Push", ShowLabel = false)]
        private PushComponent pushComponent;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Trampoline>()
                     .AsSingle();

            Container.BindInterfacesTo<EntityProxy>()
                     .FromInstance(entityProxy)
                     .AsSingle();  
            
            Container.BindInterfacesTo<PushComponent>()
                     .FromInstance(pushComponent)
                     .AsSingle();

            Container.Bind<TrampolineView>()
                     .FromInstance(view)
                     .AsSingle();
        }
    }
}