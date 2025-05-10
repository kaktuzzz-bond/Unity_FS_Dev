using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Impacts;
using Game.Scripts.Game.Core.Impacts.Pusher;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
        //     [SerializeField]
        //     private PusherData pusherData;
        //
        //     [SerializeField]
        //     private TriggerObserverData triggerObserverData;
        //     
        //     [SerializeField]
        //     private AudioSource audioSource;
        //     

        public override void InstallBindings()
        {
            // PusherInstaller.Install(Container, pusherData);
            // TriggerSensorInstaller.Install(Container, triggerObserverData);
            // AudioComponentInstaller.Install(Container, audioSource);
            //
            // EntityInstaller.Install(Container);
            //
            // Container.BindInterfacesAndSelfTo<Trampoline>()
            //          .AsSingle();
        }
    }
}