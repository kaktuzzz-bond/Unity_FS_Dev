using Game.Scripts.Presenters.HUD;
using Game.Scripts.Presenters.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters
{
    [CreateAssetMenu(
                        fileName = "PresentersInstallers",
                        menuName = "Zenject/New PresentersInstallers"
                    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MoneyViewPresenter>()
                     .AsCached();
            
            Container.BindInterfacesAndSelfTo<PlanetPresenterService>()
                     .AsSingle()
                     .NonLazy();
        }
    }
}