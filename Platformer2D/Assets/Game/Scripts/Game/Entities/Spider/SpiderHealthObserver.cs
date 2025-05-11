using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Entities.Player;
using Zenject;

namespace Game.Scripts.Game.Entities.Spider
{
    public class SpiderHealthObserver: IInitializable, IDisposable, IPlayerHealthObserver
    {
        private readonly SpiderView _view;
        private readonly IHealthComponent _healthComponent;

        public SpiderHealthObserver(SpiderView view, IHealthComponent healthComponent)
        {
            _view = view;
            _healthComponent = healthComponent;
        }

        public void Initialize()
        {
            _healthComponent.OnDeath += OnDeath;
            _healthComponent.OnHealthChanged += OnHealthChanged;
        }

        public void OnDeath()
        {
            _view.PlayDeath()
                       .Forget();
        }

        public void OnHealthChanged(float healthValue)
        {
            _view.ShowTakenDamage(healthValue)
                       .Forget();
        }

        public void Dispose()
        {
            _healthComponent.OnDeath -= OnDeath;
            _healthComponent.OnHealthChanged -= OnHealthChanged;
        }
    }
}