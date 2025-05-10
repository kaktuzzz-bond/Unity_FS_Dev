using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Lava
{
    public class LavaInstaller : MonoInstaller
    {
      
        [SerializeField]
        private TriggerObserverData triggerObserverData;

        [SerializeField]
        private AudioSource audioSource;


        public override void InstallBindings()
        {
            // AttackInstaller.Install(Container, attackData);
            // TriggerSensorInstaller.Install(Container, triggerObserverData);
            // AudioComponentInstaller.Install(Container, audioSource);
            //
            // EntityInstaller.Install(Container);
            //
            // Container.BindInterfacesAndSelfTo<Lava>()
            //          .AsSingle();
        }
    }
}