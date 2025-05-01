using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Lava
{
    public class LavaInstaller : MonoInstaller
    {
        [SerializeField]
        private AttackData attackData;

        [SerializeField]
        private TriggerObserverData triggerObserverData;

        [SerializeField]
        private AudioSource audioSource;


        public override void InstallBindings()
        {
            AttackInstaller.Install(Container, attackData);
            TriggerSensorInstaller.Install(Container, triggerObserverData);
            AudioComponentInstaller.Install(Container, audioSource);

            EntityInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<Lava>()
                     .AsSingle();
        }
    }
}