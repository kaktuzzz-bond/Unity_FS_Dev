using Game.Scripts.Components.Entity;
using Game.Scripts.Game.Core.Audio;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Core.Impacts;
using Game.Scripts.Game.Core.Impacts.Pushable;
using Game.Scripts.Game.Core.Impacts.Pusher;
using Game.Scripts.Game.Core.Jump;
using Game.Scripts.Game.Core.Movement;
using Game.Scripts.Game.Core.Sensors.EntityRaycast;
using Game.Scripts.Game.Core.Sensors.GroundRaycast;
using Game.Scripts.Game.Core.Vfx;
using Game.Scripts.Game.Entities.Installers;
using Game.Scripts.GameSystem.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField, BoxGroup("View", ShowLabel = false)]
        private PlayerView view;

        [SerializeField, BoxGroup("Audio", ShowLabel = false)]
        private AudioComponent audioComponent;
        
        [SerializeField, BoxGroup("Health", ShowLabel = false)]
        private HealthComponent healthComponent;

        [SerializeField, BoxGroup("Movement", ShowLabel = false)]
        private MoveComponent moveComponent;
        
        [SerializeField, BoxGroup("Jump", ShowLabel = false)]
        private JumpComponent jumpComponent;

        [SerializeField, BoxGroup("GroundSensor", ShowLabel = false)]
        private GroundSensor groundSensor;

        [SerializeField, BoxGroup("Blink", ShowLabel = false)]
        private BlinkSpriteComponent blinkComponent;
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
        //
        // [SerializeField]
        // private BlinkableVFXData blinkableVFXData;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Entity>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();

            Container.BindInterfacesTo<PlayerController>()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesTo<AudioComponent>()
                     .FromInstance(audioComponent)
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
            
            Container.BindInterfacesAndSelfTo<BlinkSpriteComponent>()
                     .FromInstance(blinkComponent)
                     .AsSingle();
            
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
            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();
            
        }
    }
}