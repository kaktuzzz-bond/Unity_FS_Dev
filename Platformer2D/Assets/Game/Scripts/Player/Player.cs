using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Movement.Flip;
using Game.Scripts.Components.Movement.Move;
using Game.Scripts.PlayerInput;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Player : IInitializable, IDisposable, IDamagable
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
        }

        [Button, HideInEditorMode]
        private void Move(Vector3 direction)
        {
            var mover = _entity.Get<Mover>();
            mover.Move(direction);
        }

        [Button, HideInEditorMode]
        private void Jump()
        {
            if (_entity.Get<Jumper>().Jump())
            {
                _view.PlayJump();
            }
        }

        [Button, HideInEditorMode]
        public void TakeDamage(int damage)
        {
            var healthComponent = _entity.Get<IHealthComponent>();

            healthComponent.TakeDamage(damage);

            _view.PlayTakenDamage(healthComponent.Health);
        }

        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
        }
    }
}