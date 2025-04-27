using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using Zenject;

namespace Game.Scripts.Components.Health
{
    public class HealthInstaller : Installer<HealthSettings, DamagableBody, HealthInstaller>
    {
        private readonly HealthSettings _settings;
        private readonly DamagableBody _body;

        public HealthInstaller(HealthSettings settings, DamagableBody body)
        {
            _settings = settings;
            _body = body;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(_settings.MaxHealth);

            Container.Bind<IDamagableBody>()
                     .To<DamagableBody>()
                     .FromInstance(_body)
                     .AsSingle();
        }
    }
}