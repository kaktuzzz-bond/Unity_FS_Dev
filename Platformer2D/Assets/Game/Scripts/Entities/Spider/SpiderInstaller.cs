using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Patrol;
using Game.Scripts.Components.Sensors.GroundRaycast;
using Game.Scripts.Components.Sensors.TriggerObserver;
using Game.Scripts.Components.Vfx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Spider
{
    public class SpiderInstaller : MonoInstaller
    {
        [SerializeField]
        private MovementData movementData;
        
        [SerializeField]
        private GroundSensorData groundData;

        [SerializeField]
        private PatrolData patrolData;

        [SerializeField]
        private HealthData healthData;

        [SerializeField]
        private BlinkableVFXData blinkableVFXData;

        [SerializeField]
        private TriggerObserverData triggerObserverData;

        [SerializeField]
        private ImpactTakerData impactTakerData;

        [SerializeField]
        private PusherData pusherData;

        [SerializeField]
        private AttackData attackData;

        public override void InstallBindings()
        {
            MoveInstaller.Install(Container, movementData);
            GroundSensorInstaller.Install(Container, groundData);
            PatrolInstaller.Install(Container, patrolData);
            HealthInstaller.Install(Container, healthData);
            ColorBlinkEffectInstaller.Install(Container, blinkableVFXData);
            TriggerSensorInstaller.Install(Container, triggerObserverData);
            AttackInstaller.Install(Container, attackData);
            PusherInstaller.Install(Container, pusherData);
            ImpactTakerInstaller.Install(Container, impactTakerData);

            EntityInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<Spider>()
                     .AsSingle();
        }
    }
}