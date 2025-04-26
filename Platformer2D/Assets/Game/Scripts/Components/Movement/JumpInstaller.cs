using Game.Scripts.Components.Movement.Jump;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Movement
{
    public class JumpInstaller : Installer<Transform, Rigidbody2D, LayerMask, float, JumpInstaller>
    {
        private readonly Transform _feelPoint;
        
        private readonly Rigidbody2D _rigidbodyComponent;
        
        private readonly LayerMask _groundLayer;
        
        private readonly float _jumpForce;

        public JumpInstaller(Transform feelPoint, Rigidbody2D rigidbodyComponent, LayerMask groundLayer, float jumpForce)
        {
            _feelPoint = feelPoint;
            _rigidbodyComponent = rigidbodyComponent;
            _groundLayer = groundLayer;
            _jumpForce = jumpForce;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JumpComponent>()
                     .AsSingle()
                     .WithArguments(_rigidbodyComponent, _jumpForce);

            Container.BindInterfacesTo<GroundRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_feelPoint, _groundLayer);
        }
    }
}

