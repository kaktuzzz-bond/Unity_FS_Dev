using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Force;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Sensors.TriggerSensor;
using Game.Scripts.Game.Entities.Trap;
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