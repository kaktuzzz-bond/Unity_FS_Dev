using Game.Scripts.Game.Core.Attack;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Impacts;
using Game.Scripts.Game.Core.Impacts.Pushable;
using Game.Scripts.Game.Core.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        // [SerializeField]
        // private HealthData healthData;
        //
        // [SerializeField]
        // private ImpactTakerData impactTakerData;
        //
        // [SerializeField]
        // private AttackData attackData;
        //
        // [SerializeField]
        // private TriggerObserverData triggerObserverdata;


        public override void InstallBindings()
        {
            // AttackInstaller.Install(Container, attackData);
            // TriggerSensorInstaller.Install(Container, triggerObserverdata);
            // HealthInstaller.Install(Container, healthData);
            // ImpactTakerInstaller.Install(Container, impactTakerData);
            //
            // EntityInstaller.Install(Container);
            //
            // Container.BindInterfacesAndSelfTo<Trap>()
            //          .AsSingle();
        }
    }
}