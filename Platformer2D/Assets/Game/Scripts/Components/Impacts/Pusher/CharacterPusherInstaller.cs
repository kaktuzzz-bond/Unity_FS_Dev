using Game.Scripts.Components.Cooldown;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class CharacterPusherInstaller : Installer<float, float, CharacterPusherInstaller>
    {
        private readonly float _pushForce;
        private readonly float _cooldown;

        public CharacterPusherInstaller(float pushForce, float cooldown)
        {
            _pushForce = pushForce;
            _cooldown = cooldown;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterPusher>()
                     .AsSingle()
                     .WithArguments(_pushForce, new CooldownTimer(_cooldown));
        }
    }
}