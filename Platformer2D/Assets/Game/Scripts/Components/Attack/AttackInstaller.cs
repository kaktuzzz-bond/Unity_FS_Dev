using Zenject;

namespace Game.Scripts.Components.Attack
{
    public class AttackInstaller: Installer<int, AttackInstaller>
    {
        private readonly int _attackDamage;

        public AttackInstaller(int attackDamage)
        {
            _attackDamage = attackDamage;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AttackComponent>()
                     .AsSingle()
                     .WithArguments(_attackDamage);
        }
    }
}