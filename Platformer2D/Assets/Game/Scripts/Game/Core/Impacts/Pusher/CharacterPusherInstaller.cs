using Game.Scripts.Game.Core.Cooldown;
using Zenject;

namespace Game.Scripts.Game.Core.Impacts.Pusher
{
    public class
        CharacterPusherInstaller : Installer<PusherData, DirectionData, float, string, CharacterPusherInstaller>
    {
        private readonly PusherData _data;
        private readonly DirectionData _directionData;
        private readonly float _cooldown;
        private readonly string _id;


        public CharacterPusherInstaller(PusherData data, DirectionData directionData, float cooldown, string id)
        {
            _data = data;
            _directionData = directionData;
            _cooldown = cooldown;
            _id = id;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_directionData)
                     .WithId(_id)
                     .AsCached();

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