using System;
using Game.Scripts.Views.Currency;
using Modules.Money;
using Zenject;

namespace Game.Scripts.Presenters
{
    public class CurrencyViewPresenter : IInitializable, IDisposable
    {
        private readonly ICurrencyView _currencyView;
        private readonly IMoneyStorage _moneyStorage;


        public CurrencyViewPresenter(ICurrencyView currencyView, IMoneyStorage moneyStorage)
        {
            _currencyView = currencyView;
            _moneyStorage = moneyStorage;
        }


        public void Initialize()
        {
            _currencyView.SetText(_moneyStorage.Money.ToString());
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }


        private void OnMoneyChanged(int newValue, int prevValue)
        {
            _currencyView.SetText(newValue.ToString());
        }


        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}