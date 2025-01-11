using System;
using Game.Scripts.Presenters.Planets;
using Game.Scripts.Views.HUD;
using Modules.Money;
using Modules.UI;
using Zenject;
using static Game.Scripts.Views.Common.Utils;

namespace Game.Scripts.Presenters.HUD
{
    public class MoneyViewPresenter : IInitializable, IDisposable
    {
        private readonly IMoneyView _moneyView;
        private readonly IMoneyStorage _moneyStorage;
        private readonly PlanetClickListener _planetClickListener;
        private readonly ParticleAnimator _particleAnimator;

        private const float ParticleDuration = 1f;

        private Action _onCoinsCollected;


        public MoneyViewPresenter(IMoneyView moneyView,
                                  IMoneyStorage moneyStorage,
                                  PlanetClickListener planetClickListener,
                                  ParticleAnimator particleAnimator)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
            _planetClickListener = planetClickListener;
            _particleAnimator = particleAnimator;
        }


        public void Initialize()
        {
            _planetClickListener.OnPlanetIncomeGathered += EmitParticles;

            _moneyStorage.OnMoneyEarned += OnMoneyEarned;
            _moneyStorage.OnMoneySpent += OnMoneySpent;

            ChangeMoney();
        }


        private void OnMoneySpent(int newValue, int range)
        {
            var amount = FormatInt(newValue);
            _moneyView.SpendMoney(amount);
        }


        private void OnMoneyEarned(int newValue, int range)
        {
            _onCoinsCollected = () => _moneyView.AddMoney(newValue, newValue - range);
        }


        private void EmitParticles(PlanetPresenter planetPresenter)
        {
            var from = planetPresenter.CoinPosition;
            var to = _moneyView.AttractorPosition;

            _particleAnimator.Emit(from, to, ParticleDuration, _onCoinsCollected);
        }


        private void ChangeMoney()
        {
            var amount = FormatInt(_moneyStorage.Money);
            _moneyView.ChangeMoney(amount);
        }


        public void Dispose()
        {
            _planetClickListener.OnPlanetIncomeGathered -= EmitParticles;

            _moneyStorage.OnMoneyEarned -= OnMoneyEarned;
            _moneyStorage.OnMoneySpent -= OnMoneySpent;
        }
    }
}