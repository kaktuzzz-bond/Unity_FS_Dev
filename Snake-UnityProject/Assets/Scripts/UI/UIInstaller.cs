using Modules.UI;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIInstaller : MonoInstaller<UIInstaller>
    {
        [SerializeField]
        private GameUI gameUI;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameUI>()
                     .FromInstance(gameUI)
                     .AsSingle();

            Container.BindInterfacesAndSelfTo<UIController>()
                     .AsSingle();
        }
    }
}