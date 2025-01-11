using System;
using Game.Scripts.Views.HUD;
using Modules.Money;
using Zenject;
using static Game.Scripts.Common.Utils;

namespace Game.Scripts.Presenters.HUD
{
    public class MoneyViewController : IInitializable, IDisposable
    {
        private readonly IMoneyView _moneyView;
        private readonly IMoneyStorage _moneyStorage;


        public MoneyViewController(IMoneyView moneyView, IMoneyStorage moneyStorage)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
        }


        public void Initialize()
        {
            OnMoneyChanged(_moneyStorage.Money, _moneyStorage.Money);
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }


        private void OnMoneyChanged(int newValue, int prevValue)
        {
            var price = FormatInt(_moneyStorage.Money);
            _moneyView.SetText(price);
        }


        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }
    }
}