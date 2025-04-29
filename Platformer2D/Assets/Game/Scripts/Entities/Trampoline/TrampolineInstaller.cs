using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
      
        [SerializeField]
        private TriggerObserver triggerObserver;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private TrampolineView view;

        public override void InstallBindings()
        {
            // PusherInstaller.Install(Container);
            // PusherComponentInstaller.Install(Container, triggerObserver.transform, settings);
            // TriggerSensorInstaller.Install(Container, triggerObserver);
            // AudioComponentInstaller.Install(Container, audioSource);
            // EntityInstaller.Install(Container);
            //
            // Container.Bind<TrampolineView>()
            //          .FromInstance(view)
            //          .AsSingle();
            //
            // Container.BindInterfacesAndSelfTo<Trampoline>()
            //          .AsSingle();
        }
    }
}