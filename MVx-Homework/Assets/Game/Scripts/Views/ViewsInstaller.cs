using Game.Scripts.Views.HUD;
using Game.Scripts.Views.Modifiers;
using Game.Scripts.Views.Planets;
using Game.Scripts.Views.Planets.Factory;
using Game.Scripts.Views.Popups;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [Header("Money")]
        [SerializeField]
        private MoneyView moneyView;

        [Header("Planet Factory")]
        [SerializeField]
        private PlanetView planetViewPrefab;

        [SerializeField]
        private RectTransform planetsContainer;

        [Header("Planet View Map")]
        [SerializeField]
        private PlanetViewModifier planetViewModifier;

        [Header("Planet Popup")]
        [SerializeField]
        private PlanetPopupView planetPopupView;

        [Header("Particles")]
        [SerializeField]
        private ParticleAnimator particleAnimator;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoneyView>()
                     .FromInstance(moneyView)
                     .AsCached();

            Container.Bind<IPlanetViewFactory>()
                     .To<PlanetViewFactory>()
                     .AsSingle()
                     .WithArguments(planetViewPrefab, planetsContainer, planetViewModifier);

            Container.BindInterfacesAndSelfTo<PlanetPopupView>()
                     .FromInstance(planetPopupView)
                     .AsCached();

            Container.Bind<ParticleAnimator>()
                     .FromInstance(particleAnimator)
                     .AsSingle();
        }
    }
}