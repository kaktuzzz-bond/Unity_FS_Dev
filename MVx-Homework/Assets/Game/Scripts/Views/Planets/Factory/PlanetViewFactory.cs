using Game.Scripts.Views.Modifiers;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views.Planets.Factory
{
    public class PlanetViewFactory : IPlanetViewFactory
    {
        private readonly DiContainer _diContainer;
        private readonly PlanetView _planetViewPrefab;
        private readonly Transform _parent;
        private readonly PlanetViewModifier _planetViewModifier;


        public PlanetViewFactory(DiContainer diContainer,
                                 PlanetView planetViewPrefab,
                                 Transform parent,
                                 PlanetViewModifier planetViewModifier)
        {
            _diContainer = diContainer;
            _planetViewPrefab = planetViewPrefab;
            _parent = parent;
            _planetViewModifier = planetViewModifier;
        }


        public IPlanetView Create(string name)
        {
            var go = _diContainer.InstantiatePrefab(_planetViewPrefab, _parent);

            go.name = name;
            
            var rectTransform = go.GetComponent<RectTransform>();

            _planetViewModifier.ModifyView(rectTransform);

            return go.GetComponent<IPlanetView>();
        }
    }
}