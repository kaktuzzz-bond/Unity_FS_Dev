using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Sensors
{
    public class EntitySensorInstaller : Installer<Transform, float, LayerMask, EntitySensorInstaller>
    {
        private readonly Transform _origin;
        private readonly float _raycastDistance;
        private readonly LayerMask _layer;

        public EntitySensorInstaller(Transform origin, float raycastDistance, LayerMask layer)
        {
            _origin = origin;
            _raycastDistance = raycastDistance;
            _layer = layer;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EntityRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_origin, _raycastDistance, _layer);
        }
    }
}