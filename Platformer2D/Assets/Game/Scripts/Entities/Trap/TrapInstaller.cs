using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Death;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        [BoxGroup("Settings")]
        [SerializeField, BoxGroup("Settings/Attack")]
        private int attackDamage = int.MaxValue;

        [SerializeField, BoxGroup("Settings/Sensors")]
        private TriggerObserver triggerObserver;

        [SerializeField, BoxGroup("Settings/Health")]
        private int maxHealth = 10;

        [SerializeField, BoxGroup("Settings/Health")]
        private DamagableBody damagableBody;

        [SerializeField, BoxGroup("Settings/Impacts")]
        private PushableBody pushableBody;

        [SerializeField, BoxGroup("Settings/Refs")]
        private new Rigidbody2D rigidbody;

        [SerializeField, BoxGroup("Settings/View")]
        private TrapView view;

        public override void InstallBindings()
        {
            AttackInstaller.Install(Container, attackDamage);
            TriggerSensorInstaller.Install(Container, triggerObserver);
            HealthInstaller.Install(Container, maxHealth, damagableBody);
            DeathInstaller.Install(Container, gameObject);
            ImpactTakerInstaller.Install(Container, rigidbody, pushableBody);
            
            EntityInstaller.Install(Container);
            
            Container.Bind<TrapView>()
                     .FromInstance(view)
                     .AsSingle();
            
            Container.BindInterfacesAndSelfTo<Trap>()
                     .AsSingle();
        }
    }
}