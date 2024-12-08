using Zenject;

namespace Gameplay.Management
{
    public class GameLoopInstaller : Installer<GameLoopInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameEventManager>()
                     .AsSingle()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<GameManager>()
                     .AsSingle();
        }
    }
}