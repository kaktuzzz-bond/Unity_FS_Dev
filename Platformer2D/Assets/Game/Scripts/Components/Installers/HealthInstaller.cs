using Game.Scripts.Components.Health;
using Zenject;

namespace Game.Scripts.Player
{
    public class HealthInstaller : Installer<int, HealthInstaller>
    {
        private readonly int _maxHealth;

        public HealthInstaller(int maxHealth)
        {
            _maxHealth = maxHealth;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(_maxHealth);
        }
    }
}