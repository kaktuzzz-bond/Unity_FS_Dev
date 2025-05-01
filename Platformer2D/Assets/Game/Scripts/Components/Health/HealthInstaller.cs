using Zenject;

namespace Game.Scripts.Components.Health
{
    public class HealthInstaller : Installer<HealthData, HealthInstaller>
    {
        [Inject]
        private readonly HealthData _data;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthUseCase>()
                     .AsSingle()
                     .WithArguments(_data.MaxHealth);

            Container.BindInterfacesTo<DamagableBody>()
                     .FromInstance(_data.DamagableBody)
                     .AsSingle();
            
            Container.BindInterfacesTo<DeathUseCase>()
                     .AsSingle()
                     .WithArguments(_data.GameObject);
        }
    }
}