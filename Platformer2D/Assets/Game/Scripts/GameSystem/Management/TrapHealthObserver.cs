using System;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.Game.Entities.Trap;
using Zenject;

namespace Game.Scripts.GameSystem.Management
{
    public class TrapHealthObserver : IInitializable, IDisposable, IHealthObserver
    {
        private readonly TrapView _view;
        private readonly IHealthComponent _healthComponent;

        public TrapHealthObserver(TrapView view, IHealthComponent healthComponent)
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
            _view.PlayDeath();
        }

        public void OnHealthChanged(float healthValue)
        {
        }

        public void Dispose()
        {
            _healthComponent.OnDeath -= OnDeath;
            _healthComponent.OnHealthChanged -= OnHealthChanged;
        }
    }
}