using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Sensors.EntityRaycast;
using Game.Scripts.Components.Sensors.GroundRaycast;
using Game.Scripts.Components.Vfx;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerView view;

        [SerializeField]
        private AudioSource audioSource;

        [Title("Data")]
        [SerializeField]
        private MovementData movementData;

        [SerializeField]
        private JumpData jumpData;

        [SerializeField]
        private HealthData healthData;

        [SerializeField]
        private GroundSensorData groundSensorData;

        [SerializeField]
        private EntitySensorData entitySensorData;

        [SerializeField]
        private ImpactTakerData impactTakerData;

        [SerializeField]
        private PusherData pushData;

        [SerializeField]
        private PusherData tossData;

        [SerializeField]
        private BlinkableVFXData blinkableVFXData;

        [Title("Cooldowns")]
        [SerializeField]
        private float jumpCooldown = 1;

        [SerializeField]
        private float pushCooldown = 2;

        [SerializeField]
        private float tossCooldown = 2;


        public override void InstallBindings()
        {
            AudioComponentInstaller.Install(Container, audioSource);
            CharacterMoverInstaller.Install(Container, movementData);
            CharacterJumpInstaller.Install(Container, groundSensorData, jumpData, jumpCooldown);
            HealthInstaller.Install(Container, healthData);
            ColorBlinkEffectInstaller.Install(Container, blinkableVFXData);
            ImpactTakerInstaller.Install(Container, impactTakerData);
            EntitySensorInstaller.Install(Container, entitySensorData);
            CharacterPusherInstaller.Install(Container, pushData, pushCooldown, ImpactKeys.Push);
            CharacterPusherInstaller.Install(Container, tossData, tossCooldown, ImpactKeys.Toss);

            //Entity
            EntityInstaller.Install(Container);

            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();
        }
    }
}