using SnakeGame;
using UnityEngine;

namespace Zenject
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        [SerializeField]
        private GameUI _gameUI;


        public override void InstallBindings()
        {
            Container.Bind<IGameUI>()
                     .To<GameUI>()
                     .FromInstance(_gameUI)
                     .AsSingle();
        }
    }
}