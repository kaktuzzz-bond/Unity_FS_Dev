using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Entity;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Impacts;
using Game.Scripts.Components.Impacts.Pushable;
using Game.Scripts.Components.Impacts.Pusher;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Vfx;
using Game.Scripts.Death;
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

        [SerializeField, BoxGroup("Settings/Impact")]
        private PushableBody pushableBody;

        [SerializeField, BoxGroup("Settings/Impact")]
        private float pushSensorRayLength = 1;

        [SerializeField, BoxGroup("Settings/Impact")]
        private LayerMask sensorLayer;

        [SerializeField, BoxGroup("Settings/Impact")]
        private float pushForce = 10;

        [SerializeField, BoxGroup("Settings/Impact")]
        private float pushCooldown = 2;

        [SerializeField, BoxGroup("Settings/Impact")]
        private float tossForce = 10;

        [SerializeField, BoxGroup("Settings/Impact")]
        private float tossCooldown = 2;

        [SerializeField, BoxGroup("Settings/View")]
        private PlayerView view;

        [SerializeField, BoxGroup("Settings/Audio")]
        private AudioSource audioSource;

        [SerializeField, BoxGroup("Settings/BlinkVFX")]
        private Color blinkColor = Color.white;

        [SerializeField, BoxGroup("Settings/BlinkVFX")]
        private SpriteRenderer targetSprite;

        [SerializeField, BoxGroup("Settings/BlinkVFX")]
        private float blinkDuration = 1f;

        [SerializeField, BoxGroup("Settings/BlinkVFX")]
        private int blinkFrequency = 10;

        [SerializeField, BoxGroup("Settings/Refs")]
        private Transform body;

        [SerializeField, BoxGroup("Settings/Refs")]
        private Transform feelPoint;

        [SerializeField, BoxGroup("Settings/Refs")]
        private Transform pushPoint;

        [SerializeField, BoxGroup("Settings/Refs")]
        private Rigidbody2D rigidbodyComponent;


        public override void InstallBindings()
        {
            AudioComponentInstaller.Install(Container, audioSource);

            //Movement
            MoveInstaller.Install(Container, rigidbodyComponent, body, movementSpeed, isFlippable);
            CharacterMoverInstaller.Install(Container);

            //Jump
            GroundSensorInstaller.Install(Container, feelPoint, groundLayer);
            JumpInstaller.Install(Container, rigidbodyComponent, jumpHeight, fallGravityScale);
            CharacterJumpInstaller.Install(Container, jumpCooldown);

            //Health
            HealthInstaller.Install(Container, maxHealth, damagableBody);
            DeathInstaller.Install(Container, gameObject);
            ColorBlinkEffectInstaller.Install(Container, blinkColor, targetSprite, blinkDuration, blinkFrequency);

            //Impacts
            ImpactTakerInstaller.Install(Container, rigidbodyComponent, pushableBody);
            EntitySensorInstaller.Install(Container, pushPoint, pushSensorRayLength, sensorLayer);
            CharacterPusherInstaller.Install(Container, pushForce, pushCooldown, ImpactKeys.Push);
            CharacterPusherInstaller.Install(Container, tossForce, tossCooldown, ImpactKeys.Toss);

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