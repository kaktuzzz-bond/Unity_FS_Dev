using Modules.UI;
using Zenject;

namespace UI
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameUI>()
                     .FromComponentsInHierarchy()
                     .AsSingle();

            Container.BindInterfacesTo<StartPanel>()
                     .FromComponentsInHierarchy()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<UIController>()
                     .AsCached();
        }
    }
}