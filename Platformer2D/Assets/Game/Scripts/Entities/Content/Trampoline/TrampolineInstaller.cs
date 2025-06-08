using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private TrampolineView view;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private TriggerReceiver triggerReceiver;

        [SerializeField, BoxGroup("Push", ShowLabel = false)]
        private PushComponent pushComponent;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Trampoline>()
                     .AsSingle();

            Container.BindInterfacesTo<TriggerReceiver>()
                     .FromInstance(triggerReceiver)
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