using Modules.Difficulty;
using Modules.Score;
using World;
using Zenject;

namespace Loop
{
    public class GameLoopInstaller : Installer<int, GameLoopInstaller>
    {
        private readonly int _maxDifficulty;


        public GameLoopInstaller(int maxDifficulty)
        {
            _maxDifficulty = maxDifficulty;
        }


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameLoop>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<GameLoopObserver>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerDeathObserver>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<Difficulty>()
                     .AsSingle()
                     .WithArguments(_maxDifficulty);

            Container.BindInterfacesAndSelfTo<Score>()
                     .AsSingle();
            
            Container.BindInterfacesAndSelfTo<CoinsManager>()
                     .AsSingle();
        }
    }
}