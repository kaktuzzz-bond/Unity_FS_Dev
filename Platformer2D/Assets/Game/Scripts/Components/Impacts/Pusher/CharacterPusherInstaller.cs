using Game.Scripts.Components.Cooldown;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class CharacterPusherInstaller : Installer<PusherData, float, string, CharacterPusherInstaller>
    {
        private readonly PusherData _data;
        private readonly float _cooldown;
        private readonly string _id;


        public CharacterPusherInstaller(PusherData data, float cooldown, string id)
        {
            _data = data;
            _cooldown = cooldown;
            _id = id;
        }

        public override void InstallBindings()
        {
            Container.Bind<CharacterPusher>()
                     .WithId(_id)
                     .AsCached()
                     .WithArguments(new Pusher(_data.Force), new CooldownTimer(_cooldown));

            Container.BindInterfacesTo<CharacterPusher>()
                     .FromMethod(ctx => ctx.Container.ResolveId<CharacterPusher>(_id));

            Container.Bind<ICharacterPusher>()
                     .WithId(_id)
                     .To<CharacterPusher>()
                     .FromMethod(ctx => ctx.Container.ResolveId<CharacterPusher>(_id));
        }
    }
}