using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Entities
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

        [SerializeField, BoxGroup("GroundSensor", ShowLabel = false)]
        private GroundSensor groundSensor;

        [SerializeField, BoxGroup("Trigger", ShowLabel = false)]
        private EntityProxy entityProxy;
        
        [SerializeField, BoxGroup("Force", ShowLabel = false)]
        private ForceComponent forceComponent;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Spider>()
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

            Container.BindInterfacesTo<ForceComponent>()
                     .FromInstance(forceComponent)
                     .AsSingle();

            Container.Bind<SpiderView>()
                     .FromInstance(view)
                     .AsSingle();
        }
    }
}