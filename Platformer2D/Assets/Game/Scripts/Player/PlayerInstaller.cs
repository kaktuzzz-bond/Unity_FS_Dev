using Game.Scripts.Components.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
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

        [Title("Settings")]
        [SerializeField]
        private float moveSpeed = 5;

        [SerializeField]
        private float jumpForce = 10;

        [SerializeField]
        private int maxHealth = 10;

        public override void InstallBindings()
        {
            MoveInstaller.Install(Container, rigidbodyComponent, moveSpeed);
            FlipInstaller.Install(Container, body);
            JumpInstaller.Install(Container, feelPoint, rigidbodyComponent, groundLayer, jumpForce);
            HealthInstaller.Install(Container, maxHealth);

            Container.BindInterfacesTo<Player>()
                     .AsSingle();
        }
    }
}