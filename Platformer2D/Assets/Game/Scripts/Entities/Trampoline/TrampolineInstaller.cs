using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField]
        private PushSettings settings;

        [SerializeField]
        private TriggerSensor triggerSensor;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private TrampolineView view;

        public override void InstallBindings()
        {
            PusherInstaller.Install(Container, settings);
            TriggerSensorInstaller.Install(Container, triggerSensor);
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