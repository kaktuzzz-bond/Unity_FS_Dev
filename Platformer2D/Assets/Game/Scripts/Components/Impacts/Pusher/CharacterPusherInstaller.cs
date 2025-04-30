using Game.Scripts.Components.Cooldown;
using Unity.VisualScripting;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class CharacterPusherInstaller : Installer<float, float, string, CharacterPusherInstaller>
    {
        private readonly float _force;
        private readonly float _cooldown;
        private readonly string _id;


        public CharacterPusherInstaller(float force, float cooldown, string id)
        {
            _force = force;
            _cooldown = cooldown;
            _id = id;
        }

        public override void InstallBindings()
        {
           
            
            Container.Bind<CharacterPusher>()
                     .WithId(_id)
                     .AsCached()
                     .WithArguments(new Pusher(_force), new CooldownTimer(_cooldown));
            
            Container.BindInterfacesTo<CharacterPusher>()
                     .FromMethod(ctx=> ctx.Container.ResolveId<CharacterPusher>(_id))
                     .AsCached();
        }
    }
}