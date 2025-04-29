using Zenject;

namespace Game.Scripts.Components.Impacts
{
    public class PusherInstaller:Installer<PusherInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Pusher>()
                     .AsSingle();
        }
    }
}