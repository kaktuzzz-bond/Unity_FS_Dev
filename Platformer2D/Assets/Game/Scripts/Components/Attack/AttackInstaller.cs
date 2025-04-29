using Zenject;

namespace Game.Scripts.Components.Attack
{
    public class AttackInstaller:Installer<int, AttackInstaller>
    {
        private readonly int _damage;

        public AttackInstaller(int damage)
        {
            _damage = damage;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AttackUseCase>()
                     .AsSingle()
                     .WithArguments(_damage);
        }
    }
}