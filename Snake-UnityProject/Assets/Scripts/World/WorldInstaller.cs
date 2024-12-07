using Modules.World;
using Zenject;

namespace World
{
    public class WorldInstaller : Installer<WorldInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WorldBounds>()
                     .FromComponentInHierarchy()
                     .AsSingle();
        }
    }
}