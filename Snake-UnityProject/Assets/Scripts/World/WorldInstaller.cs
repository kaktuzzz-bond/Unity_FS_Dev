using Modules.Coin;
using Modules.World;
using Zenject;

namespace World
{
    public class WorldInstaller : Installer<Coin, WorldInstaller>
    {
        private readonly Coin _coinPrefab;


        public WorldInstaller(Coin coinPrefab)
        {
            _coinPrefab = coinPrefab;
        }
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WorldBounds>()
                     .FromComponentInHierarchy()
                     .AsSingle();
            
            Container.BindMemoryPool<Coin, CoinSpawner>()
                     .FromComponentInNewPrefab(_coinPrefab)
                     .WithGameObjectName("Coin")
                     .AsSingle();
            
        }
    }
}