using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Views.Planets.Factory
{
    public class PlanetViewFactory : IPlanetViewFactory
    {
        private readonly DiContainer _diContainer;
        private readonly PlanetView _planetViewPrefab;
        private readonly Transform _parent;


        public PlanetViewFactory(DiContainer diContainer, PlanetView planetViewPrefab, Transform parent)
        {
            _diContainer = diContainer;
            _planetViewPrefab = planetViewPrefab;
            _parent = parent;
        }


        public IPlanetView Create(Vector3 at, string name)
        {
            var go = _diContainer.InstantiatePrefab(_planetViewPrefab, _parent);
            
            go.name = name;
            go.transform.localScale = Vector3.one;

            var rt = go.GetComponent<RectTransform>();
            rt.anchoredPosition = at;
           

            
            return go.GetComponent<IPlanetView>();
        }
    }
}