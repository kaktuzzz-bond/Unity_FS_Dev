using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerController>()
                     .AsSingle()
                     .NonLazy();
        }
    }
}