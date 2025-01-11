using Game.Scripts.Presenters.HUD;
using Game.Scripts.Presenters.Planets;
using Game.Scripts.Presenters.Popups;
using Game.Scripts.Presenters.VFX;
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
            Container.BindInterfacesTo<PlanetPresenterService>()
                     .AsCached()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<PopupShower>()
                     .AsCached()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<MoneyViewPresenter>()
                     .AsCached();

            Container.BindInterfacesAndSelfTo<PlanetPopupController>()
                     .AsCached()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<PlanetClickListener>()
                     .AsCached()
                     .NonLazy();

            Container.BindInterfacesAndSelfTo<ParticlePresenter>()
                     .AsCached();
        }
    }
}