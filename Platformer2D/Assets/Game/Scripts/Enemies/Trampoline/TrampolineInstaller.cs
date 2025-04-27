using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Trampoline
{
    public class TrampolineInstaller : MonoInstaller
    {
        [SerializeField]
        private Vector3 force = new(0, 20f, 0);

        [SerializeField]
        private TriggerSensor triggerSensor;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private TrampolineView view;

        public override void InstallBindings()
        {
            PushInstaller.Install(Container, force);
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