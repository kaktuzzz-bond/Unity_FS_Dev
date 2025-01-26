using Zenject;

namespace Game.Scripts.PlayerInput
{
    public class PlayerInputInstaller : Installer<PlayerInputInstaller>
    {
      
        public override void InstallBindings()
        {
            Container.Bind<PLayerInputMap>()
                     .AsSingle();

            Container.BindInterfacesTo<PlayerInputBroadcast>()
                     .AsSingle();
        }
    }
}