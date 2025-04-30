using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Sensors;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Lava
{
    public class LavaInstaller : MonoInstaller
    {
        [BoxGroup("Settings")]
        [SerializeField, BoxGroup("Settings/Attack")]
        private int attackDamage = int.MaxValue;

        [SerializeField, BoxGroup("Settings/Sensors")]
        private TriggerObserver triggerObserver;

        [SerializeField, BoxGroup("Settings/Refs")]
        private AudioSource audioSource;

        [SerializeField, BoxGroup("Settings/View")]
        private LavaView view;

        public override void InstallBindings()
        {
            AttackInstaller.Install(Container, attackDamage);
            TriggerSensorInstaller.Install(Container, triggerObserver);
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