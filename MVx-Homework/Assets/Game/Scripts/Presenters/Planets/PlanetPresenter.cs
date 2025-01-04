using System;
using Game.Scripts.Views.Planets;
using Modules.Planets;
using UnityEngine;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenter : IDisposable
    {
        private readonly IPlanet _planet;
        private readonly IPlanetView _planetView;


        public PlanetPresenter(IPlanet planet, IPlanetView planetView)
        {
            _planet = planet;
            _planetView = planetView;

            Initialize();
        }


        public void Initialize()
        {
            UpdateView();

            _planetView.OnClick += OnPlanetClicked;
            _planetView.OnHold += OnPlanetHold;
        }


        private void UpdateView()
        {
            var isUnlocked = _planet.IsUnlocked;

            _planetView.SetIcon(_planet.GetIcon(isUnlocked));
            _planetView.SetPrice(_planet.Price.ToString());

            _planetView.ShowProgress(isUnlocked);
            _planetView.ShowCoin(isUnlocked);
            
            _planetView.ShowPrice(!isUnlocked);
        }


        private void OnPlanetHold()
        {
            Debug.Log($"{_planet.Name} hold");
        }


        private void OnPlanetClicked()
        {
            Debug.Log($"{_planet.Name} clicked");
        }


        public void Dispose()
        {
            _planetView.OnClick -= OnPlanetClicked;
            _planetView.OnHold -= OnPlanetHold;
        }
    }
}