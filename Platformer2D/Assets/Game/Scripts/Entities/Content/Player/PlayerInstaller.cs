using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Entities
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private PlayerView view;

        [SerializeField, BoxGroup("Health", ShowLabel = false)]
        private HealthComponent healthComponent;

        [SerializeField, BoxGroup("Movement", ShowLabel = false)]
        private MoveComponent moveComponent;

        [SerializeField, BoxGroup("Jump", ShowLabel = false)]
        private JumpComponent jumpComponent;

        [SerializeField, BoxGroup("GroundSensor", ShowLabel = false)]
        private GroundSensor groundSensor;

        [SerializeField, BoxGroup("Force", ShowLabel = false)]
        private ForceComponent forceComponent;

        [SerializeField, BoxGroup("Pusher", ShowLabel = false)]
        private EntitySensor pusher;

        [SerializeField, BoxGroup("Tosser", ShowLabel = false)]
        private EntitySensor tosser;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveComponent>()
                     .FromInstance(moveComponent)
                     .AsSingle();

            Container.BindInterfacesTo<HealthComponent>()
                     .FromInstance(healthComponent)
                     .AsSingle();

            Container.BindInterfacesTo<JumpComponent>()
                     .FromInstance(jumpComponent)
                     .AsSingle();

            Container.BindInterfacesTo<GroundSensor>()
                     .FromInstance(groundSensor)
                     .AsSingle();

            Container.BindInterfacesTo<ForceComponent>()
                     .FromInstance(forceComponent)
                     .AsSingle();

            BindPusher(PushKey.Push, pusher);
            BindPusher(PushKey.Toss, tosser);

            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();

            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesTo<PlayerController>()
                     .AsSingle()
                     .NonLazy();
        }

        private void BindPusher(PushKey id, EntitySensor instance)
        {
            Container.Bind<EntitySensor>()
                     .WithId(id)
                     .FromInstance(instance)
                     .AsCached();

            Container.BindInterfacesTo<EntitySensor>()
                     .FromMethod(it => it.Container.ResolveId<EntitySensor>(id));
        }
    }
}