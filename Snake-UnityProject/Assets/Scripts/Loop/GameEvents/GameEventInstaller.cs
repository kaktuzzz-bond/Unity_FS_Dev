using Zenject;

namespace Loop.GameEvents
{
    public class GameEventInstaller: Installer<GameEventInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameEventManager>()
                     .AsSingle()
                     .NonLazy();
        }
    }
}