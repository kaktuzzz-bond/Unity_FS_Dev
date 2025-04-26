using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Flip;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Player : IInitializable, IDisposable, IPlayer
    {
        public event Action<float> OnHealthChanged;

        private readonly IPlayerInput _playerInput;
        private readonly IMovable _moveComponent;
        private readonly IFlippable _flipComponent;
        private readonly IJumpable _jumpComponent;
        private readonly IGroundRaycastSensor _groundRaycastSensor;
        private readonly IHealthComponent _healthComponent;

        private readonly CompositeCondition _jumpCondition;
        private readonly CompositeCondition _moveCondition;

        public Player(
            IPlayerInput playerInput, IMovable moveComponent, IFlippable flipComponent, IJumpable jumpComponent,
            IGroundRaycastSensor groundRaycastSensor, IHealthComponent healthComponent)
        {
            _playerInput = playerInput;
            _moveComponent = moveComponent;
            _flipComponent = flipComponent;
            _jumpComponent = jumpComponent;
            _groundRaycastSensor = groundRaycastSensor;
            _healthComponent = healthComponent;
            _jumpCondition = new CompositeCondition(
                () => _groundRaycastSensor.IsGrounded,
                () => !_healthComponent.IsDead);

            _moveCondition = new CompositeCondition(
                () => !_healthComponent.IsDead);
        }

        public void Initialize()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
        }

        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
        }

        private void Move(Vector3 direction)
        {
            if (!_moveCondition.IsValid) return;
            _flipComponent.LookTowards(direction);
            _moveComponent.Move(direction);
        }

        private void Jump()
        {
            if (!_jumpCondition.IsValid) return;
            _jumpComponent.Jump();
        }


        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
            OnHealthChanged?.Invoke(_healthComponent.Health);
        }
    }
}