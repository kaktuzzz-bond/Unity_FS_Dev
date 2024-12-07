using Zenject;

namespace Loop
{
    public class GameLoopInstaller : Installer<GameLoopInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameLoop>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<GameLoopObserver>()
                     .AsSingle();
        }
    }
}