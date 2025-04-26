using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement;
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
        public PlayerView view;

        [Title("Refs")]
        [SerializeField]
        public Transform body;

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
                config,
                config.MoveSettings,
                config.JumpSettings,
                config.HealthSettings,
                config.AttackSettings
            );

            MoveInstaller.Install(Container, rigidbodyComponent, config.MoveSettings);
            FlipInstaller.Install(Container, body);
            JumpInstaller.Install(Container, feelPoint, rigidbodyComponent, groundLayer, config.JumpSettings);
            HealthInstaller.Install(Container, config.HealthSettings);

            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.BindInterfacesTo<Entity>()
                     .AsSingle()
                     .WithArguments(Container);

            Container.BindInterfacesAndSelfTo<JumpValidator>()
                     .AsSingle();
            
            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();
        }
    }
}