using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Sensors;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        [Title("Settings")]
      

        [Title("Sensors")]
        [SerializeField]
        private TriggerObserver triggerObserver;
        
        [SerializeField]
        private DamagableBody damagableBody;
        
        [SerializeField]
        private PushableBody pushableBody;
        
        [Title("Refs")]
        [SerializeField]
        private new Rigidbody2D rigidbody;
        
        [Title("View")]
        [SerializeField]
        private TrapView view;

        public override void InstallBindings()
        {
            // AttackInstaller.Install(Container, attackSettings.AttackDamage);
            // TriggerSensorInstaller.Install(Container, triggerObserver);
            // HealthInstaller.Install(Container, healthSettings, damagableBody);
            // PushableInstaller.Install(Container, rigidbody, pushableBody);
            // EntityInstaller.Install(Container);
            //
            // Container.Bind<TrapView>()
            //          .FromInstance(view)
            //          .AsSingle();
            //
            // Container.BindInterfacesAndSelfTo<Trap>()
            //          .AsSingle();
        }
    }
}