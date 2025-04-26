using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement.Flip;
using Game.Scripts.Components.Movement.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Player.Settings;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Player : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IEntity _entity;
        private readonly PlayerView _view;

        private CompositeCondition _jumpCondition;
        private CompositeCondition _moveCondition;
        private CooldownTimer _jumpCooldown;

        public Player(IPlayerInput playerInput, IEntity entity, PlayerView view)
        {
            _playerInput = playerInput;
            _entity = entity;
            _view = view;
        }


        public void Initialize()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;

            AddMoveConditions();
        }

        [Button, HideInEditorMode]
        private void Move(Vector3 direction)
        {
            if (!_moveCondition.IsValid) return;

            var flippable = _entity.Get<IFlippable>();
            var movable = _entity.Get<IMovable>();

            flippable.LookTowards(direction);
            movable.Move(direction);
        }

        [Button, HideInEditorMode]
        private void Jump()
        {
            var jumpValidator = _entity.Get<JumpValidator>();
            var jumpable = _entity.Get<IJumpable>();

            if (!jumpValidator.Jump()) return;
            
            jumpable.Jump();
            _view.PlayJump();

        }

        [Button, HideInEditorMode]
        private void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IHealthComponent>();

            healthComponent.TakeDamage(damage);

            _view.PlayTakenDamage(healthComponent.Health);
        }


        private void AddMoveConditions()
        {
            var healthComponent = _entity.Get<IHealthComponent>();

            _moveCondition = new CompositeCondition(() => healthComponent.IsAlive);
        }

        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
        }
    }
}