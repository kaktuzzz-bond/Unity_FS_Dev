using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Game.Core.Health;
using Game.Scripts.GameSystem.Management;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class PlayerHealthObserver : IInitializable, IDisposable, IHealthObserver
    {
        private readonly PlayerView _playerView;
        private readonly IHealthComponent _healthComponent;

        public PlayerHealthObserver(PlayerView playerView, IHealthComponent healthComponent)
        {
            _playerView = playerView;
            _healthComponent = healthComponent;
        }

        public void Initialize()
        {
            _healthComponent.OnDeath += OnDeath;
            _healthComponent.OnHealthChanged += OnHealthChanged;
        }

        public void OnDeath()
        {
            _playerView.PlayDeath()
                       .Forget();
        }

        public void OnHealthChanged(float healthValue)
        {
            _playerView.ShowTakenDamage(healthValue)
                       .Forget();
        }

        public void Dispose()
        {
            _healthComponent.OnDeath -= OnDeath;
            _healthComponent.OnHealthChanged -= OnHealthChanged;
        }
    }
}