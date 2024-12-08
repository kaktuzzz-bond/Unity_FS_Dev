using Modules.Snake;
using Zenject;

namespace Player
{
    public class PlayerInstaller : Installer<Snake, PlayerInstaller>

    {
        private readonly Snake _snakePrefab;


        public PlayerInstaller(Snake snakePrefab)
        {
            _snakePrefab = snakePrefab;
        }


        public override void InstallBindings()
        {
            Container.BindFactory<Snake, PlayerSpawner.PlayerFactory>()
                     .FromComponentInNewPrefab(_snakePrefab)
                     .WithGameObjectName("Snake")
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerSpawner>()
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerManager>()
                     .AsSingle();
        }
    }
}