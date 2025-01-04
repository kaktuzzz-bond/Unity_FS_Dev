using System;
using Game.Scripts.Views.HUD;
using Modules.Money;
using Zenject;

namespace Game.Scripts.Presenters.HUD
{
    public class MoneyViewPresenter : IInitializable, IDisposable
    {
        private readonly IMoneyView _moneyView;
        private readonly IMoneyStorage _moneyStorage;


        public MoneyViewPresenter(IMoneyView moneyView, IMoneyStorage moneyStorage)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
        }


        public void Initialize()
        {
            _moneyView.SetText(_moneyStorage.Money.ToString());
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }


        private void OnMoneyChanged(int newValue, int prevValue)
        {
            _moneyView.SetText(newValue.ToString());
        }


        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}