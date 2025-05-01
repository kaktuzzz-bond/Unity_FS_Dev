using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Sensors.TriggerObserver;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Trap
{
    public class TrapInstaller : MonoInstaller
    {
        [SerializeField]
        private HealthData healthData;

        [SerializeField]
        private ImpactTakerData impactTakerData;

        [SerializeField]
        private AttackData attackData;

        [SerializeField]
        private TriggerObserverData triggerObserverdata;


        public override void InstallBindings()
        {
            AttackInstaller.Install(Container, attackData);
            TriggerSensorInstaller.Install(Container, triggerObserverdata);
            HealthInstaller.Install(Container, healthData);
            ImpactTakerInstaller.Install(Container, impactTakerData);

            EntityInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<Trap>()
                     .AsSingle();
        }
    }
}