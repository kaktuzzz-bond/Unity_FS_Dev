using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherInstaller : Installer<Transform, PushSettings, PusherInstaller>
    {
        private readonly Transform _origin;
        private readonly PushSettings _settings;

        public PusherInstaller(Transform origin, PushSettings settings)
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
                     .WithArguments(_origin);

        }
    }
}