using Game.Scripts.Components.Health;
using Game.Scripts.Components.Movement;
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
            MoveInstaller.Install(Container, rigidbodyComponent, config.MoveSpeed);
            FlipInstaller.Install(Container, body);
            JumpInstaller.Install(Container, feelPoint, rigidbodyComponent, groundLayer, config.JumpForce);
            HealthInstaller.Install(Container, config.MaxHealth);
            
            Container.Bind<PlayerView>()
                     .FromInstance(view)
                     .AsSingle();

            Container.Bind<IEntity>()
                     .To<Entity>()
                     .AsSingle()
                     .WithArguments(Container);
            
            Container.BindInterfacesAndSelfTo<Player>()
                     .AsSingle();
        }
    }
}