using System;
using Modules;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
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

        [SerializeField, BoxGroup("EntitySensor", ShowLabel = false)]
        private EntitySensorComponent entitySensor;

        [FormerlySerializedAs("pushableComponentComponent")]
        [SerializeField, BoxGroup("Impact", ShowLabel = false)]
        private PushableComponent pushableComponent;

        [SerializeField, BoxGroup("Pusher", ShowLabel = false)]
        private PushComponent pusher;

        [SerializeField, BoxGroup("Tosser", ShowLabel = false)]
        private PushComponent tosser;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();

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

            Container.BindInterfacesTo<EntitySensorComponent>()
                     .FromInstance(entitySensor)
                     .AsSingle();

            Container.BindInterfacesTo<PushableComponent>()
                     .FromInstance(pushableComponent)
                     .AsSingle();

            BindPusher(typeof(IPushAdapter), pusher);
            BindPusher(typeof(ITossAdapter), tosser);
        }


        private void BindPusher(Type id, PushComponent instance)
        {
            Container.Bind<PushComponent>()
                     .WithId(id)
                     .FromInstance(instance)
                     .AsCached();

            Container.BindInterfacesTo<PushComponent>()
                     .FromMethod(it => it.Container.ResolveId<PushComponent>(id));
        }
    }
}