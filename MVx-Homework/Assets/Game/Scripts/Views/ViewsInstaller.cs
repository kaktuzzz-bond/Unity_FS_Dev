using Game.Scripts.Views.HUD;
using Game.Scripts.Views.Modifiers;
using Game.Scripts.Views.Planets;
using Game.Scripts.Views.Planets.Factory;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyView moneyView;

        [SerializeField]
        private PlanetView planetViewPrefab;

        [SerializeField]
        private RectTransform planetsContainer;
       
        [SerializeField]
        private PlanetViewModifier planetViewModifier;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoneyView>()
                     .FromInstance(moneyView)
                     .AsCached();

            Container.Bind<IPlanetViewFactory>()
                     .To<PlanetViewFactory>()
                     .AsSingle()
                     .WithArguments(planetViewPrefab, planetsContainer, planetViewModifier);
        }
    }
}