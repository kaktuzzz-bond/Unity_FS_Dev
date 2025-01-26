using Game.Scripts.Components;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
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

        [SerializeField]
        private float moveSpeed = 5;

        [SerializeField]
        private float jumpForce = 10;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<FlipComponent>()
                     .AsSingle()
                     .WithArguments(root);
            
            Container.BindInterfacesTo<MoveComponent>()
                     .AsSingle()
                     .WithArguments(rigidbodyComponent, moveSpeed);

            Container.BindInterfacesTo<JumpComponent>()
                     .AsSingle()
                     .WithArguments(rigidbodyComponent, jumpForce);

            Container.BindInterfacesTo<GroundRaycastComponent>()
                     .AsSingle()
                     .WithArguments(feelPoint, groundLayer);
        }
    }
}