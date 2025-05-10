using Zenject;

namespace Game.Scripts.Game.Core.Impacts.Pusher
{
    public class PusherInstaller : Installer<PusherData, PusherInstaller>
    {
        [Inject]
        private readonly PusherData _data;

      

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Pusher>()
                     .AsCached()
                     .WithArguments(_data.Force);
        }
    }
}