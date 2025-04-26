using Game.Scripts.Player.Settings;
using Zenject;

namespace Game.Scripts.Components.Health
{
    public class HealthInstaller : Installer<HealthSettings, HealthInstaller>
    {
        private readonly HealthSettings _settings;

        public HealthInstaller(HealthSettings settings)
        {
            _settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(_settings.MaxHealth);
        }
    }
}