using Game.Scripts.Components.Audio;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Entities;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement;
using Game.Scripts.Components.Movement.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [Title("Settings")]
        [SerializeField]
        private EntityConfig config;

        [Title("View")]
        [SerializeField]
        private PlayerView view;

        [Title("Audio")]
        [SerializeField]
        private AudioSource audioSource;
        
        [Title("Refs")]
        [SerializeField]
        private DamagableBody damagableBody;
        
        [SerializeField]
        private Transform body;

        [SerializeField]
        private Transform feelPoint;

        [SerializeField]
        private Transform pushPoint;

        [SerializeField]
        private Rigidbody2D rigidbodyComponent;

        [SerializeField]
        private LayerMask groundLayer;


        public override void InstallBindings()
        {
            Container.BindInstances(
                config//,
                // config.MoveSettings,
                // config.JumpSettings,
                // config.HealthSettings,
                // config.AttackSettings
            );

            MoveInstaller.Install(Container, rigidbodyComponent, body, config.MoveSettings);
            JumpInstaller.Install(Container, feelPoint, rigidbodyComponent, groundLayer, config.JumpSettings);
            HealthInstaller.Install(Container, config.HealthSettings);
            BodyInstaller.Install(Container, damagableBody);
            AudioInstaller.Install(Container, audioSource);
            EntityInstaller.Install(Container);
            
            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();
        }
    }
}