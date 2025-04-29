using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherComponentInstaller : Installer<Transform, PushSettings, PusherComponentInstaller>
    {
        private readonly Transform _origin;
        private readonly PushSettings _settings;

        public PusherComponentInstaller(Transform origin, PushSettings settings)
        {
            _origin = origin;
            _settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PusherComponent>()
                     .AsSingle()
                     .WithArguments(_settings);

            Container.BindInterfacesTo<EntityRaycastSensor>()
                     .AsSingle()
                     .WithArguments(_origin, _settings.RaycastDistance);

        }
    }
}