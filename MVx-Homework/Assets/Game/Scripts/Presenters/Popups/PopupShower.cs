using Game.Scripts.Views.Popups;
using Modules.Planets;

namespace Game.Scripts.Presenters.Popups
{
    public class PopupShower
    {
        private readonly PlanetPopupView _view;

        private IPlanet _planet;


        public PopupShower(PlanetPopupView view)
        {
            _view = view;
        }


        public void Show(IPlanet planet)
        {
            _planet = planet;

            _planet.OnUnlocked += OnUnlockedHandler;
            _planet.OnPopulationChanged += OnPopulationChangedHandler;
            _planet.OnUpgraded += OnUpgradedHandler;
            _planet.OnIncomeChanged += OnIncomeChangedHandler;

            _view.OnCloseClicked += Hide;
            _view.OnUpgradeClicked += OnUpgradeClickedHandler;

            _view.Show();

            UpdateView();
        }


        private void UpdateView()
        {
            SetHeader();
            OnUnlockedHandler();
            OnPopulationChangedHandler(_planet.Population);
            OnUpgradedHandler(_planet.Level);
            OnIncomeChangedHandler(_planet.NextMinuteIncome);
        }


        private void OnUpgradeClickedHandler()
        {
            _planet.UnlockOrUpgrade();
        }


        private void SetHeader()
        {
            _view.SetHeaderText(_planet.Name);
        }


        private void OnUnlockedHandler()
        {
            _view.SetAvatar(_planet.GetIcon(_planet.IsUnlocked));
        }


        private void OnIncomeChangedHandler(int value)
        {
            _view.SetIncomeText($"Income: {value} / sec");
        }


        private void OnUpgradedHandler(int value)
        {
            _view.SetLevelText($"Level: {value}/{_planet.MaxLevel}");
            _view.SetPriceText($"Price: {_planet.Price}");

            if (_planet.MaxLevel != _planet.Level)
            {
                _view.SetButtonInteractable(true);
                _view.SetButtonText("Upgrade");
            }
            else
            {
                _view.SetButtonInteractable(false);
                _view.SetButtonText("MaxLevel");
            }
        }


        private void OnPopulationChangedHandler(int value)
        {
            _view.SetPopulationText($"Population: {value}");
        }


        private void Hide()
        {
            _planet.OnUnlocked -= OnUnlockedHandler;
            _planet.OnPopulationChanged -= OnPopulationChangedHandler;
            _planet.OnUpgraded -= OnUpgradedHandler;
            _planet.OnIncomeChanged -= OnIncomeChangedHandler;

            _view.OnCloseClicked -= Hide;
            _view.OnUpgradeClicked -= OnUpgradeClickedHandler;
            _view.Hide();
        }
    }
}