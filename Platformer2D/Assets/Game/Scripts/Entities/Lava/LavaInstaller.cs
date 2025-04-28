using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Lava
{
    public class LavaInstaller : MonoInstaller
    {
        [SerializeField]
        private AttackSettings attackSettings;

        [SerializeField]
        private TriggerSensor triggerSensor;

        [SerializeField]
        private AudioSource audioSource;
        
        [SerializeField]
        private LavaView view;

        public override void InstallBindings()
        {
            AttackInstaller.Install(Container, attackSettings.AttackDamage);
            TriggerSensorInstaller.Install(Container, triggerSensor);
            AudioComponentInstaller.Install(Container, audioSource);
            EntityInstaller.Install(Container);

            Container.Bind<LavaView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Lava>()
                     .AsSingle();
        }
    }
}