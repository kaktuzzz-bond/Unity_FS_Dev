using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField]
        private float pushForce = 10;

        [SerializeField]
        private TriggerObserver triggerObserver;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private TrampolineView view;

        public override void InstallBindings()
        {
            PusherInstaller.Install(Container, pushForce);
            TriggerSensorInstaller.Install(Container, triggerObserver);
            AudioComponentInstaller.Install(Container, audioSource);
            
            EntityInstaller.Install(Container);
            Container.Bind<TrampolineView>()
                     .FromInstance(view)
                     .AsSingle();
            Container.BindInterfacesAndSelfTo<Trampoline>()
                     .AsSingle();
        }
    }
}