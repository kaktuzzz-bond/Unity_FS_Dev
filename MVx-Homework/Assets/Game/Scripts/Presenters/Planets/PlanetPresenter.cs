using System;
using Game.Scripts.Views.Planets;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly IPlanet _planet;
        private readonly IPlanetView _planetView;


        public PlanetPresenter(IPlanet planet, IPlanetView planetView)
        {
            _planet = planet;
            _planetView = planetView;
        }


        public void Initialize()
        {
            _planetView.OnClicked += OnPlanetClicked;
        }


        private void OnPlanetClicked()
        {
            Debug.Log($"{_planet.Name} clicked");
        }


        public void Dispose()
        {
            _planetView.OnClicked -= OnPlanetClicked;
        }
    }
}