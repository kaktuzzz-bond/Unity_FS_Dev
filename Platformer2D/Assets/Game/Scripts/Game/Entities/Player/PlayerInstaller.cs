using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Force;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Jump;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Sensors.EntityRaycast;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.Game.Entities.Installers;
using Modules.Entity;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
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
        
        [SerializeField, BoxGroup("EntitySensor", ShowLabel = false)]
        private EntitySensor entitySensor;

        // [SerializeField]
        // private EntitySensorData entitySensorData;
        //
        // [SerializeField]
        // private ImpactTakerData impactTakerData;
        //
        // [SerializeField]
        // private PusherData pushData;
        //
        // [SerializeField]
        // private DirectionData pushDirectionData;
        //
        // [SerializeField]
        // private DirectionData tossDirectionData;
        //
        // [SerializeField]
        // private PusherData tossData;


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

            Container.BindInterfacesTo<EntitySensor>()
                     .FromInstance(entitySensor)
                     .AsSingle();

            Container.BindInterfacesTo<ForceComponent>()
                     .FromInstance(forceComponent)
                     .AsSingle();
            
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

            Container.BindInterfacesTo<PlayerHealthObserver>()
                     .AsSingle()
                     .NonLazy();

            // CharacterMoverInstaller.Install(Container, movementData);
            // CharacterJumpInstaller.Install(Container, groundSensorData, jumpData, jumpCooldown);
            // HealthInstaller.Install(Container, healthData);
            // ColorBlinkEffectInstaller.Install(Container, blinkableVFXData);
            // ImpactTakerInstaller.Install(Container, impactTakerData);
            // EntitySensorInstaller.Install(Container, entitySensorData);
            // CharacterPusherInstaller.Install(Container, pushData, pushDirectionData, pushCooldown, ImpactKeys.Push);
            // CharacterPusherInstaller.Install(Container, tossData, tossDirectionData, tossCooldown, ImpactKeys.Toss);
            //
            //Entity

            //
        }
    }
}