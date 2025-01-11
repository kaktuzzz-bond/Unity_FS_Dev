using Game.Scripts.Views.Popups;
using Modules.Money;
using Modules.Planets;
using static Game.Scripts.Views.Common.Utils;

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
            _planet.OnUpgraded += OnLevelUp;
            _planet.OnIncomeChanged += SetIncomeInfo;
            _planet.OnPopulationChanged += SetPopulationInfo;

            _moneyStorage.OnMoneyChanged += OnMoneyChanged;

            _view.UpgradeButton.OnClicked += OnUpdateButtonClicked;
            _view.OnCloseClicked += Hide;

            SetHeader();
            SetAvatar(_planet.IsUnlocked);
            UpdateInfo();

            _view.Show();
        }


        private void OnUpdateButtonClicked() =>
            _planet.UnlockOrUpgrade();


        private void OnUnlocked()
        {
            SetAvatar(true);
            UpdateInfo();
        }


        private void OnLevelUp(int value)
        {
            SetLevelInfo(value);
            UpdateInfo();
        }


        private void UpdateInfo()
        {
            SetPopulationInfo(_planet.Population);
            SetLevelInfo(_planet.Level);
            SetIncomeInfo(_planet.MinuteIncome);
            SetPriceButtonInfo();
        }


        private void OnMoneyChanged(int newValue, int prevValue) =>
            SetUpgradeButtonInteractable();


        private void SetHeader() =>
            _view.SetHeaderText(_planet.Name);


        private void SetAvatar(bool isUnlocked) =>
            _view.PlanetInfoPanel.SetAvatar(_planet.GetIcon(isUnlocked));


        private void SetIncomeInfo(int value) =>
            _view.PlanetInfoPanel.SetIncomeText($"Income: {FormatInt(_planet.MinuteIncome/60)} / sec");


        private void SetPopulationInfo(int value) =>
            _view.PlanetInfoPanel.SetPopulationText($"Population: {value}");


        private void SetLevelInfo(int value) =>
            _view.PlanetInfoPanel.SetLevelText($"Level: {value}/{_planet.MaxLevel}");


        private void SetUpgradeButtonInteractable() =>
            _view.UpgradeButton.SetButtonInteractable(_planet.CanUnlock || _planet.CanUpgrade);


        private void SetPriceButtonInfo()
        {
            if (_planet.Level == _planet.MaxLevel)
            {
                _view.UpgradeButton.SetText("MAX LEVEL");
                _view.UpgradeButton.SetButtonInteractable(false);
                _view.UpgradeButton.Price.SetActive(false);

                return;
            }

            _view.UpgradeButton.Price.SetActive(true);
            _view.UpgradeButton.SetText(_planet.IsUnlocked ? "Upgrade" : "Unlock");
            _view.UpgradeButton.Price.SetText($"{FormatInt(_planet.Price)}");
            SetUpgradeButtonInteractable();
        }


        private void Hide()
        {
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnUpgraded -= OnLevelUp;
            _planet.OnIncomeChanged -= SetIncomeInfo;
            _planet.OnPopulationChanged -= SetPopulationInfo;

            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;

            _view.UpgradeButton.OnClicked -= OnUpdateButtonClicked;
            _view.OnCloseClicked -= Hide;

            _view.Hide();
        }
    }
}