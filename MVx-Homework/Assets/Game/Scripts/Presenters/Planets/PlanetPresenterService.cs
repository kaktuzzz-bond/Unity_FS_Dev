using System;
using System.Collections.Generic;
using Game.Scripts.Views.Planets.Factory;
using Modules.Planets;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenterService : IInitializable, IDisposable
    {
        public event Action<IPlanet> OnPlanetClicked;
        public event Action<IPlanet> OnPlanetHold;

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

                presenter.OnPlanetClicked += OnPlanetClickedHandler;
                presenter.OnPlanetHold += OnPlanetHoldHandler;

                _presenters.Add(presenter);
            }
        }


        private void OnPlanetHoldHandler(IPlanet planet) =>
            OnPlanetHold?.Invoke(planet);


        private void OnPlanetClickedHandler(IPlanet planet) =>
            OnPlanetClicked?.Invoke(planet);


        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.OnPlanetClicked -= OnPlanetClickedHandler;
                presenter.OnPlanetHold -= OnPlanetHoldHandler;
            }

            _presenters.Clear();
        }
    }
}