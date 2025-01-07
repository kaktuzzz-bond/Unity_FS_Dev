using System;
using Game.Scripts.Views.Planets;
using Modules.Planets;
using UnityEngine;

namespace Game.Scripts.Presenters.Planets
{
    public class PlanetPresenter : IDisposable
    {
        // public event Action<IPlanet> OnPlanetClicked;
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
            _planet.OnUpgraded += OnPlanetUpgraded;
            _planet.OnIncomeReady += OnPlanetIncomeReady;
            _planet.OnGathered += OnPlanetIncomeGathered;

            _planetView.OnClick += OnClick;
            _planetView.OnHold += OnHold;

            UpdateView();
        }


        private void OnPlanetUpgraded(int obj)
        {
            _planetView.SetPrice(_planet.Price.ToString());

            if (_planet.Level == _planet.MaxLevel)
            {
                _planetView.ShowPrice(false);
            }
        }


        private void OnPlanetIncomeGathered(int _)
        {
            _planetView.ShowProgressbar(true);
            _planetView.ShowCoin(false);
        }


        private void OnPlanetIncomeReady(bool isIncomeReady)
        {
            _planetView.ShowProgressbar(false);
            _planetView.ShowCoin(true);
        }


        private void OnHold() =>
            OnPlanetHold?.Invoke(_planet);


        private void OnClick()
        {
            if (!_planet.IsUnlocked && _planet.CanUnlock)
            {
                _planet.Unlock();
                return;
            }

            if (_planet.IsIncomeReady)
            {
                _planet.GatherIncome();
            }
        }


        private void OnPlanetUnlock()
        {
            if (_planet.CanUnlock)
            {
                Debug.LogWarning("Cannot unlock the planet");

                return;
            }
            
            _planet.Unlock();
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
            _planet.OnUpgraded -= OnPlanetUpgraded;
            _planet.OnIncomeReady -= OnPlanetIncomeReady;
            _planet.OnGathered -= OnPlanetIncomeGathered;

            _planetView.OnClick -= OnClick;
            _planetView.OnHold -= OnHold;
        }
    }
}