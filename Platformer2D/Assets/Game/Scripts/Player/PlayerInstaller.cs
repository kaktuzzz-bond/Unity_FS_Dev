using Game.Scripts.Components;
using Game.Scripts.Components.Flip;
using Game.Scripts.Components.GroundDetection;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Move;
using Game.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [Title("Refs")]
        [SerializeField]
        public Transform root;

        [SerializeField]
        private Transform feelPoint;

        [SerializeField]
        private Transform pushPoint;

        [SerializeField]
        private Rigidbody2D rigidbodyComponent;

        [SerializeField]
        private LayerMask groundLayer;

        [Title("Settings")]
        [SerializeField]
        private float moveSpeed = 5;

        [SerializeField]
        private float jumpForce = 10;

        [SerializeField]
        private int maxHealth = 10;
        [SerializeField]
        private int startHealth = 10;

        [Title("UI")]
        [SerializeField]
        private HealthBarView playerHealthBar;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FlipComponent>()
                     .AsSingle()
                     .WithArguments(root);

            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(maxHealth, startHealth);

            Container.BindInterfacesTo<MoveComponent>()
                     .AsSingle()
                     .WithArguments(rigidbodyComponent, moveSpeed);

            Container.BindInterfacesTo<JumpComponent>()
                     .AsSingle()
                     .WithArguments(rigidbodyComponent, jumpForce);

            Container.BindInterfacesTo<GroundRaycastComponent>()
                     .AsSingle()
                     .WithArguments(feelPoint, groundLayer);

            Container.Bind<HealthBarView>()
                     .FromInstance(playerHealthBar)
                     .AsSingle();
        }
    }
}