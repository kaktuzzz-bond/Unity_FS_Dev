using Zenject;

namespace Game.Scripts.Components.Attack
{
    public class AttackInstaller : Installer<AttackData, AttackInstaller>
    {
        [Inject]
        private readonly AttackData _data;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AttackUseCase>()
                     .AsSingle()
                     .WithArguments(_data.Damage);
        }
    }
}