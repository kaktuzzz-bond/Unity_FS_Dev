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

        [SerializeField, BoxGroup("GroundSensor", ShowLabel = false)]
        private GroundSensor groundSensor;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private EntityProxy entityProxy;

        [SerializeField, BoxGroup("Force", ShowLabel = false)]
        private PushableComponent pushableComponent;

        [SerializeField, BoxGroup("Pusher", ShowLabel = false)]
        private PushComponent pushComponent;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Snake>()
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

            Container.BindInterfacesTo<GroundSensor>()
                     .FromInstance(groundSensor)
                     .AsSingle();

            Container.BindInterfacesTo<EntityProxy>()
                     .FromInstance(entityProxy)
                     .AsSingle();

            Container.BindInterfacesTo<PushableComponent>()
                     .FromInstance(pushableComponent)
                     .AsSingle();

            Container.BindInterfacesTo<PushComponent>()
                     .FromInstance(pushComponent)
                     .AsSingle();

            Container.Bind<SnakeView>()
                     .FromInstance(view)
                     .AsSingle();
        }
    }
}