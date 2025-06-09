using Zenject;

namespace Game.GameSystem
{
    public class PlayerInputInstaller : Installer<PlayerInputInstaller>
    {
      
        public override void InstallBindings()
        {
            Container.Bind<PLayerInputMap>()
                     .AsSingle();

            Container.BindInterfacesTo<PlayerInputBroadcaster>()
                     .AsSingle();
        }
    }
}