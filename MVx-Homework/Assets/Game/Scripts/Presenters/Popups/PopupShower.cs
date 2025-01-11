using Game.Scripts.Views.Popups;
using Modules.Money;
using Modules.Planets;
using UnityEngine;

namespace Game.Scripts.Presenters.Popups
{
    public class PopupShower
    {
        private readonly PlanetPopupView _view;
        private readonly IMoneyStorage _moneyStorage;

        private IPlanet _planet;


        public PopupShower(PlanetPopupView view, IMoneyStorage moneyStorage)
        {
            _view = view;
            _moneyStorage = moneyStorage;
        }


        public void Show(IPlanet planet)
        {
            _planet = planet;

            _planet.OnUnlocked += OnUnlocked;
            _planet.OnUpgraded += SetLevelInfo;
            _planet.OnIncomeChanged += SetIncomeInfo;
            _planet.OnPopulationChanged += SetPopulationInfo;

            _moneyStorage.OnMoneyChanged += SetInteractableButtonState;

            _view.UpgradeButton.OnClicked += OnUpdateButtonClicked;
            _view.OnCloseClicked += Hide;

            SetHeader();
            SetAvatar(_planet.IsUnlocked);
            UpdateInfo();

            _view.Show();
        }


        private void OnUpdateButtonClicked() =>
            _planet.UnlockOrUpgrade();


        private void UpdateInfo()
        {
            SetPopulationInfo(_planet.Population);
            SetLevelInfo(_planet.Level);
            SetIncomeInfo(_planet.MinuteIncome);

            SetPriceButtonInfo();
        }


        private void SetInteractableButtonState(int newValue, int prevValue) =>
            _view.UpgradeButton.SetButtonInteractable(_planet.CanUnlock || _planet.CanUpgrade);


        private void SetHeader() =>
            _view.SetHeaderText(_planet.Name);


        private void OnUnlocked()
        {
            SetAvatar(true);
            UpdateInfo();
        }


        private void SetAvatar(bool isUnlocked) =>
            _view.PlanetInfoPanel.SetAvatar(_planet.GetIcon(isUnlocked));


        private void SetIncomeInfo(int value) =>
            _view.PlanetInfoPanel.SetIncomeText($"Income: {value} / sec");


        private void SetPopulationInfo(int value) =>
            _view.PlanetInfoPanel.SetPopulationText($"Population: {value}");


        private void SetLevelInfo(int value) =>
            _view.PlanetInfoPanel.SetLevelText($"Level: {value}/{_planet.MaxLevel}");


        private void SetPriceButtonInfo()
        {
            if (_planet.Level == _planet.MaxLevel)
            {
                _view.UpgradeButton.SetText("MAX LEVEL");
                _view.UpgradeButton.Price.SetActive(false);

                return;
            }

            _view.UpgradeButton.SetText(_planet.IsUnlocked ? "Upgrade" : "Unlock");
            _view.UpgradeButton.Price.SetText(_planet.Price.ToString());
        }


        private void Hide()
        {
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnPopulationChanged -= SetPopulationInfo;
            _planet.OnUpgraded -= SetLevelInfo;
            _planet.OnIncomeChanged -= SetIncomeInfo;

            _view.OnCloseClicked -= Hide;
            _view.UpgradeButton.OnClicked -= OnUpdateButtonClicked;

            _moneyStorage.OnMoneyChanged -= SetInteractableButtonState;

            _view.Hide();
        }
    }
}