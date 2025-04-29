using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Sensors
{
    public class GroundSensorInstaller : Installer<Transform, LayerMask, GroundSensorInstaller>
    {
        private readonly Transform _origin;
        private readonly LayerMask _groundLayer;
        
        public GroundSensorInstaller(Transform origin, LayerMask groundLayer)
        {
            _origin = origin;
            _groundLayer = groundLayer;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GroundRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_origin, _groundLayer);
        }
    }
}