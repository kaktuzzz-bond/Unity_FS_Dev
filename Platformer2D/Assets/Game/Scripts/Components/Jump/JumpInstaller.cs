using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class JumpInstaller : Installer<Transform, Rigidbody2D, LayerMask, JumpSettings, JumpInstaller>
    {
        private readonly Transform _feelPoint;
        private readonly Rigidbody2D _rigidbodyComponent;
        private readonly LayerMask _groundLayer;
        private readonly JumpSettings _settings;

        public JumpInstaller(
            Transform feelPoint,
            Rigidbody2D rigidbodyComponent,
            LayerMask groundLayer,
            JumpSettings settings)
        {
            _feelPoint = feelPoint;
            _rigidbodyComponent = rigidbodyComponent;
            _groundLayer = groundLayer;
            _settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<JumpComponent>()
                     .AsSingle()
                     .WithArguments(_rigidbodyComponent, _settings);

            Container.BindInterfacesTo<GroundRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_feelPoint, _groundLayer);
        }
    }
}