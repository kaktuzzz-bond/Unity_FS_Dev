using Game.Scripts.Player.Settings;
using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherInstaller : Installer<PushSettings, PusherInstaller>
    {
        private readonly PushSettings _settings;

        public PusherInstaller(PushSettings settings)
        {
            _settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PusherComponent>()
                     .AsSingle()
                     .WithArguments(_settings);
        }
    }
}