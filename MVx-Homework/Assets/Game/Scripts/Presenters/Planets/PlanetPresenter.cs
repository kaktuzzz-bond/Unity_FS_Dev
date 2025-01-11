using System;
using Game.Scripts.Common;
using Game.Scripts.Views.Planets;
using Modules.Planets;
using UnityEngine;
using static Game.Scripts.Common.Utils;

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
            _planet.OnUpgraded += OnPlanetUpgraded;
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnIncomeReady += OnPlanetIncomeReady;
            _planet.OnGathered += OnPlanetIncomeGathered;

            _planetView.OnClick += OnClick;
            _planetView.OnHold += OnHold;

            UpdateView();
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
            _planetView.ShowProgressbar(true);

            UpdateView();
        }


        private void OnPlanetUpgraded(int level)
        {
            SetPrice();

            if (level == _planet.MaxLevel)
            {
                _planetView.ShowPrice(false);
            }
        }


        private void UpdateView()
        {
            _planetView.SetPlanetIcon(_planet.GetIcon(_planet.IsUnlocked));
            SetPrice();
        }


        private void SetPrice()
        {
            var price = FormatInt(_planet.Price);
            _planetView.SetPrice(price);
        }


        private void OnIncomeTimeChanged(float value)
        {
            if (_planet.IsIncomeReady)
                return;

            var time = Utils.SecondsToText(value);

            _planetView.SetProgress(_planet.IncomeProgress, time);
        }


        private void OnPlanetIncomeGathered(int _)
        {
            _planetView.ShowProgressbar(true);
            _planetView.ShowCoin(false);
        }


        private void OnPlanetIncomeReady(bool isReady)
        {
            if (!isReady) return;

            _planetView.ShowProgressbar(false);
            _planetView.ShowCoin(true);
        }


        private void OnHold() =>
            OnPlanetHold?.Invoke(_planet);


        private void OnClick() =>
            OnPlanetClicked?.Invoke(_planet);


        public void Dispose()
        {
            _planet.OnUnlocked -= OnPlanetUnlock;
            _planet.OnUpgraded -= OnPlanetUpgraded;
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnIncomeReady -= OnPlanetIncomeReady;
            _planet.OnGathered -= OnPlanetIncomeGathered;

            _planetView.OnClick -= OnClick;
            _planetView.OnHold -= OnHold;
        }
    }
}