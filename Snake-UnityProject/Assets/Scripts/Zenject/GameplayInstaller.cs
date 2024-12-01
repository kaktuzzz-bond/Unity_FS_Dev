using Modules;
using SampleGame;
using UnityEngine;

namespace Zenject
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>

    {
        [SerializeField]
        private PlayerInputMap playerInputMap;

        [SerializeField]
        private Snake snake;


        public override void InstallBindings()
        {
            BindPlayerInputMap();
            BindPlayerInput();
            BindSnake();
            BindPlayerController();
        }


        private void BindPlayerController()
        {
            Container.BindInterfacesAndSelfTo<PlayerController>()
                     .AsSingle();
        }


        private void BindSnake()
        {
            Container.Bind<ISnake>()
                     .To<Snake>()
                     .FromInstance(snake)
                     .AsSingle();
        }


        private void BindPlayerInput()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>()
                     .AsSingle();
        }


        private void BindPlayerInputMap()
        {
            Container.Bind<PlayerInputMap>()
                     .FromInstance(playerInputMap)
                     .AsSingle();
        }
    }
}