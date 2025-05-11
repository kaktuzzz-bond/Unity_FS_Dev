using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Entities.Snake;
using Game.Scripts.Game.Entities.Spider;
using Zenject;

namespace Game.Scripts.GameSystem.Management
{
    public class SnakeHealthObserver: IInitializable, IDisposable, IHealthObserver
    {
        private readonly SnakeView _view;
        private readonly IHealthComponent _healthComponent;

        public SnakeHealthObserver(SnakeView view, IHealthComponent healthComponent)
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