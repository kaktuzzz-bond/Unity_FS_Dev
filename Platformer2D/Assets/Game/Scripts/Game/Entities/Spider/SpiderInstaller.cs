using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Patrol;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Spider
{
    public class SpiderInstaller : MonoInstaller
    {
        // [SerializeField]
        // private MovementData movementData;
        //
        // [SerializeField]
        // private GroundSensorData groundData;
        //
        // [SerializeField]
        // private PatrolData patrolData;
        //
        // [SerializeField]
        // private HealthData healthData;
        //
        // [SerializeField]
        // private BlinkableVFXData blinkableVFXData;
        //
        // [SerializeField]
        // private TriggerObserverData triggerObserverData;
        //
        // [SerializeField]
        // private ImpactTakerData impactTakerData;
        //
        // [SerializeField]
        // private PusherData pusherData;
        //
        // [SerializeField]
        // private AttackData attackData;

        public override void InstallBindings()
        {
            // MoveInstaller.Install(Container, movementData);
            // GroundSensorInstaller.Install(Container, groundData);
            // PatrolInstaller.Install(Container, patrolData);
            // HealthInstaller.Install(Container, healthData);
            // ColorBlinkEffectInstaller.Install(Container, blinkableVFXData);
            // TriggerSensorInstaller.Install(Container, triggerObserverData);
            // AttackInstaller.Install(Container, attackData);
            // PusherInstaller.Install(Container, pusherData);
            // ImpactTakerInstaller.Install(Container, impactTakerData);
            //
            // EntityInstaller.Install(Container);
            //
            // Container.BindInterfacesAndSelfTo<Spider>()
            //          .AsSingle();
        }
    }
}