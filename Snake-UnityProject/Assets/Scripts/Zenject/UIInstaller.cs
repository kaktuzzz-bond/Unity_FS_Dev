using Modules.UI;
using UnityEngine;

namespace Zenject
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        [SerializeField]
        private GameUI gameUI;


        public override void InstallBindings()
        {
            BindGameUI();
        }


        private void BindGameUI()
        {
            Container.Bind<IGameUI>()
                     .To<GameUI>()
                     .FromInstance(gameUI)
                     .AsSingle();
        }
    }
}