using System;
using Game.Scripts.Views.Planets;
using Modules.Planets;
using UnityEngine;

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
            _planetView.SetPrice(_planet.Price.ToString());

            if (level == _planet.MaxLevel)
            {
                _planetView.ShowPrice(false);
            }
        }


        private void UpdateView()
        {
            _planetView.SetPlanetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _planetView.SetPrice(_planet.Price.ToString());
        }


        private void OnIncomeTimeChanged(float value)
        {
            if (_planet.IsIncomeReady)
                return;

            var minutes = Mathf.FloorToInt(value / 60f);
            var seconds = Mathf.FloorToInt(value % 60f);

            var time = string.Empty;
            if (minutes > 0) time += $"{minutes}m:";
            if (seconds >= 0) time += $"{seconds + 1}s";

            _planetView.SetProgress(_planet.IncomeProgress, time);
        }


        private void OnPlanetIncomeGathered(int _)
        {
            Debug.Log("Planet income GATHERED");
            _planetView.ShowProgressbar(true);
            _planetView.ShowCoin(false);
        }


        private void OnPlanetIncomeReady(bool isReady)
        {
            if (!isReady) return;

            Debug.Log("Planet income READY");
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