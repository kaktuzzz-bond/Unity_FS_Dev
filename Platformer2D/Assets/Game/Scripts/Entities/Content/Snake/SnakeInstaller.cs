using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class SnakeInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private SnakeView view;

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

        public override void InstallBindings()
        {
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

            Container.BindInterfacesAndSelfTo<Snake>()
                     .AsSingle();

            Container.Bind<SnakeView>()
                     .FromInstance(view)
                     .AsSingle();
        }
    }
}