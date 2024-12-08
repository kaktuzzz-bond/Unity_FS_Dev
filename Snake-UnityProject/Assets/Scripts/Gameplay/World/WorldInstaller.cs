using Modules.Coin;
using Modules.Difficulty;
using Modules.Score;
using Modules.World;
using Zenject;

namespace Gameplay.World
{
    public class WorldInstaller : Installer<Coin, int, WorldInstaller>
    {
        private readonly Coin _coinPrefab;


        private readonly int _maxDifficulty;


        public WorldInstaller(Coin coinPrefab, int maxDifficulty)
        {
            _coinPrefab = coinPrefab;
            _maxDifficulty = maxDifficulty;
        }


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WorldBounds>()
                     .FromComponentInHierarchy()
                     .AsSingle();

            Container.BindMemoryPool<Coin, CoinSpawner>()
                     .FromComponentInNewPrefab(_coinPrefab)
                     .WithGameObjectName("Coin")
                     .UnderTransformGroup("[Coins]")
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinsManager>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinCollector>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Difficulty>()
                     .AsSingle()
                     .WithArguments(_maxDifficulty);

            Container.BindInterfacesAndSelfTo<Score>()
                     .AsSingle();
        }
    }
}