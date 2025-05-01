using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField]
        private PusherData pusherData;

        [SerializeField]
        private TriggerObserverData triggerObserverData;
        
        [SerializeField]
        private AudioSource audioSource;
        

        public override void InstallBindings()
        {
            PusherInstaller.Install(Container, pusherData);
            TriggerSensorInstaller.Install(Container, triggerObserverData);
            AudioComponentInstaller.Install(Container, audioSource);
            
            EntityInstaller.Install(Container);
           
            Container.BindInterfacesAndSelfTo<Trampoline>()
                     .AsSingle();
        }
    }
}