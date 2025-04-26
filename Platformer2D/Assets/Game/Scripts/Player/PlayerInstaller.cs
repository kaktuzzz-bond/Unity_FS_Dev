using Game.Scripts.Components.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private EntityConfig config;

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
            
            Container.BindInterfacesTo<Player>()
                     .AsSingle();
        }
    }
}