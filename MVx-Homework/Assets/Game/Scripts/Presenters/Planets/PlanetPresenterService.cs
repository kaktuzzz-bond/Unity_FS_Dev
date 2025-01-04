using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Views.Planets.Factory;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenterService : IInitializable, IEnumerable<PlanetPresenter>
    {
        private readonly Planet[] _planets;
        private readonly IPlanetViewFactory _planetViewFactory;

        private readonly List<PlanetPresenter> _presenters = new();


        public PlanetPresenterService(Planet[] planets, IPlanetViewFactory planetViewFactory)
        {
            _planets = planets;
            _planetViewFactory = planetViewFactory;
        }


        public void Initialize()
        {
            foreach (var planet in _planets)
            {
                var view = _planetViewFactory.Create(planet.Name);

                var presenter = new PlanetPresenter(planet, view);

                _presenters.Add(presenter);
            }
        }


        public IEnumerator<PlanetPresenter> GetEnumerator() =>
            _presenters.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}