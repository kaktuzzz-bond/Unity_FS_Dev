using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Force;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Patrol;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.Game.Core.Sensors.TriggerSensor;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Spider
{
    public class SpiderInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private SpiderView view;

        [SerializeField, BoxGroup("Health", ShowLabel = false)]
        private HealthComponent healthComponent;

        [SerializeField, BoxGroup("Movement", ShowLabel = false)]
        private PatrolComponent patrolComponent;

        [SerializeField, BoxGroup("Attack", ShowLabel = false)]
        private AttackComponent attackComponent;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private TriggerReceiver triggerReceiver;

        [SerializeField, BoxGroup("GroundSensor", ShowLabel = false)]
        private GroundSensor groundSensor;

        [SerializeField, BoxGroup("Force", ShowLabel = false)]
        private ForceComponent forceComponent;

        [SerializeField, BoxGroup("Force", ShowLabel = false)]
        private ForceData forceData;

        public override void InstallBindings()
        {
            Container.BindInstance(forceData)
                     .AsSingle();

            Container.BindInterfacesTo<HealthComponent>()
                     .FromInstance(healthComponent)
                     .AsSingle();

            Container.BindInterfacesTo<PatrolComponent>()
                     .FromInstance(patrolComponent)
                     .AsSingle();

            Container.BindInterfacesTo<AttackComponent>()
                     .FromInstance(attackComponent)
                     .AsSingle();

            Container.BindInterfacesTo<TriggerReceiver>()
                     .FromInstance(triggerReceiver)
                     .AsSingle();

            Container.BindInterfacesTo<GroundSensor>()
                     .FromInstance(groundSensor)
                     .AsSingle();

            Container.BindInterfacesTo<ForceComponent>()
                     .FromInstance(forceComponent)
                     .AsSingle();

            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Spider>()
                     .AsSingle();

            Container.Bind<SpiderView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesTo<SpiderHealthObserver>()
                     .AsSingle()
                     .NonLazy();
        }
    }
}