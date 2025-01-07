using System;
using Game.Scripts.Views.Planets;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenter : IDisposable
    {
        public event Action<IPlanet> OnPlanetClicked;
        public event Action<IPlanet> OnPlanetHold;

        private readonly IPlanet _planet;
        private readonly IPlanetView _planetView;


        public PlanetPresenter(IPlanet planet, IPlanetView planetView)
        {
            _planet = planet;
            _planetView = planetView;

            Initialize();
        }


        private void Initialize()
        {
            _planet.OnUnlocked += OnPlanetUnlock;
            _planet.OnIncomeReady += OnPlanetIncomeReady;
            _planet.OnGathered += OnPlanetIncomeGathered;

            _planetView.OnClick += OnClick;
            _planetView.OnHold += OnHold;

            UpdateView();
        }


        private void OnPlanetIncomeGathered(int obj)
        {
            _planetView.ShowProgressbar(true);
            _planetView.ShowCoin(false);
        }


        private void OnPlanetIncomeReady(bool isIncomeReady)
        {
            _planetView.ShowProgressbar(!isIncomeReady);
            _planetView.ShowCoin(isIncomeReady);
        }


        private void OnHold() =>
            OnPlanetHold?.Invoke(_planet);


        private void OnClick() =>
            OnPlanetClicked?.Invoke(_planet);


        private void OnPlanetUnlock()
        {
            _planetView.ShowLockIcon(false);
            UpdateView();
        }


        private void UpdateView()
        {
            _planetView.SetPlanetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _planetView.SetPrice(_planet.Price.ToString());
        }


        public void Dispose()
        {
            _planet.OnUnlocked -= OnPlanetUnlock;

            _planetView.OnClick -= OnClick;
            _planetView.OnHold -= OnHold;
        }
    }
}