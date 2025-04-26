using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Movement.Flip;
using Game.Scripts.Components.Movement.Jump;
using Game.Scripts.Components.Movement.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Player : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IEntity _entity;
        private readonly PlayerView _view;

        private readonly CompositeCondition _jumpCondition;
        private readonly CompositeCondition _moveCondition;

        public Player(IPlayerInput playerInput, IEntity entity, PlayerView view)
        {
            _playerInput = playerInput;
            _entity = entity;
            _view = view;

            var healthComponent = _entity.Get<IHealthComponent>();
            var groundSensor = _entity.Get<IGroundRaycastSensor>();

            _jumpCondition = new CompositeCondition(
                () => groundSensor.IsGrounded,
                () => healthComponent.IsAlive);

            _moveCondition = new CompositeCondition(() => healthComponent.IsAlive);
        }


        public void Initialize()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
        }


        private void Move(Vector3 direction)
        {
            if (!_moveCondition.IsValid) return;
            
            var flippable = _entity.Get<IFlippable>();
            var movable = _entity.Get<IMovable>();
            
            flippable.LookTowards(direction);
            movable.Move(direction);
        }

        private void Jump()
        {
            if (!_jumpCondition.IsValid) return;
            
            var jumpable = _entity.Get<IJumpable>();
            jumpable.Jump();
        }

        private void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IHealthComponent>();

            healthComponent.TakeDamage(damage);

            _view.ShowTakenDamage(healthComponent.Health);
        }

        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
        }
    }
}