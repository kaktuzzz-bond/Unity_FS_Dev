using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Sensors;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Entities.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [BoxGroup("Settings")]
        [SerializeField, BoxGroup("Settings/Movement")]
        private float movementSpeed = 5;

        [SerializeField, BoxGroup("Settings/Movement")]
        private bool isFlippable = true;

        [SerializeField, BoxGroup("Settings/Jump")]
        private float jumpHeight = 5;

        [SerializeField, BoxGroup("Settings/Jump")]
        private float fallGravityScale = 3;

        [SerializeField, BoxGroup("Settings/Jump")]
        private float jumpCooldown = 1;

        [SerializeField, BoxGroup("Settings/Jump")]
        private LayerMask groundLayer;

        [SerializeField, BoxGroup("Settings/Health")]
        private int maxHealth = 10;

        [SerializeField, BoxGroup("Settings/Health")]
        private DamagableBody damagableBody;

        [Title("View")]
        [SerializeField]
        private PlayerView view;

        [Title("Audio")]
        [SerializeField]
        private AudioSource audioSource;

        [Title("Sensors")]
        [SerializeField]
        private PushableBody pushableBody;

        [Title("Refs")]
        [SerializeField]
        private Transform body;

        [SerializeField]
        private Transform feelPoint;

        [SerializeField]
        private Transform pushPoint;

        [SerializeField]
        private Rigidbody2D rigidbodyComponent;


        public override void InstallBindings()
        {
            AudioComponentInstaller.Install(Container, audioSource);

            InstallMovement();

            InstallJump();

            HealthInstaller.Install(Container, maxHealth, damagableBody);

            // PushableInstaller.Install(Container, rigidbodyComponent, pushableBody);
            // PusherComponentInstaller.Install(Container, pushPoint, config.PushSettings);

            InstallEntity();
        }

        private void InstallEntity()
        {
            EntityInstaller.Install(Container);

            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();
        }

        private void InstallJump()
        {
            GroundSensorInstaller.Install(Container, feelPoint, groundLayer);
            JumpInstaller.Install(Container, rigidbodyComponent, jumpHeight, fallGravityScale);
            CharacterJumpInstaller.Install(Container, jumpCooldown);
        }


        private void InstallMovement()
        {
            MoveInstaller.Install(Container, rigidbodyComponent, body, movementSpeed, isFlippable);
            CharacterMoverInstaller.Install(Container);
        }
    }
}