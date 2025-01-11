using System;
using System.Collections.Generic;
using Game.Scripts.Views.Planets.Factory;
using Modules.Planets;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenterService : IPlanetPresenterService, IInitializable, IDisposable
    {
        public event Action<IPlanet> OnPlanetClicked;
        public event Action<IPlanet> OnPlanetHold;


        private readonly Planet[] _planets;

        private readonly IPlanetViewFactory _planetViewFactory;

        private readonly Dictionary<IPlanet, PlanetPresenter> _presenters = new();


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

                presenter.OnPlanetHold += OnPlanetHoldHandler;
                presenter.OnPlanetClicked += OnPlanetClickedHandler;

                _presenters.Add(planet, presenter);
            }
        }


        private void OnPlanetHoldHandler(IPlanet planet) =>
            OnPlanetHold?.Invoke(planet);


        private void OnPlanetClickedHandler(IPlanet planet) =>
            OnPlanetClicked?.Invoke(planet);


        public PlanetPresenter GetPlanetPresenter(IPlanet planet)
        {
            if (!_presenters.TryGetValue(planet, out var planetPresenter))
                throw new Exception($"Planet presenter {planet} has not been registered.");

            return planetPresenter;
        }


        public void Dispose()
        {
            foreach (var presenter in _presenters.Values)
            {
                presenter.OnPlanetHold -= OnPlanetHoldHandler;
                presenter.OnPlanetClicked -= OnPlanetClickedHandler;
            }

            _presenters.Clear();
        }
    }
}