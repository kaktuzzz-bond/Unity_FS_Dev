using Game.Scripts.Components.Cooldown;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class CharacterJumpInstaller : Installer<float, CharacterJumpInstaller>
    {
        private readonly float _cooldown;

        public CharacterJumpInstaller(float cooldown)
        {
            _cooldown = cooldown;
        }

        public override void InstallBindings()
        {
            
            Container.BindInterfacesTo<CharacterJumper>()
                     .AsSingle()
                     .WithArguments(new CooldownTimer(_cooldown));
            
        }
    }
}