using Game.Scripts.Game.Core.Force;
using Game.Scripts.Game.Core.Sensors.TriggerSensor;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private TrampolineView view;

        [SerializeField, BoxGroup("ForceData", ShowLabel = false)]
        private ForceData forceData;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private TriggerReceiver triggerReceiver;


        public override void InstallBindings()
        {
            
            Container.BindInstance(forceData)
                     .AsSingle();

            Container.BindInterfacesTo<TriggerReceiver>()
                     .FromInstance(triggerReceiver)
                     .AsSingle();
            
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.Bind<TrampolineView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Trampoline>()
                     .AsSingle();
        }
        
    }
}