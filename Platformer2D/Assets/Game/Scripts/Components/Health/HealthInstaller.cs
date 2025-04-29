using Zenject;

namespace Game.Scripts.Components.Health
{
    public class HealthInstaller : Installer<int, IDamagableBody, HealthInstaller>
    {
        private readonly int _maxHealth;
        private readonly IDamagableBody _body;

        public HealthInstaller(int maxHealth, IDamagableBody body)
        {
            _maxHealth = maxHealth;
            _body = body;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthUseCase>()
                     .AsSingle()
                     .WithArguments(_maxHealth);

            Container.BindInterfacesTo<DamagableBody>()
                     .FromInstance(_body)
                     .AsSingle();
        }
    }
}