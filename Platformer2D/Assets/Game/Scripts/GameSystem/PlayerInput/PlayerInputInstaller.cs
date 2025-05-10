using Zenject;

namespace Game.Scripts.GameSystem.PlayerInput
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