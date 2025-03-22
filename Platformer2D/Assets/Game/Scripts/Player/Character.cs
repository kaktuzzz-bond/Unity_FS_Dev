using System;
using Game.Scripts.Components;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Flip;
using Game.Scripts.Components.GroundDetection;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Move;
using Game.Scripts.PlayerInput;
using Game.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Character : MonoBehaviour
    {
        public event Action OnDeath;
        
        [SerializeField]
        private HealthBarView healthBarView;
        
        private IPlayerInput _playerInput;
        private IMoveComponent _moveComponent;
        private IFlipComponent _flipComponent;
        private IJumpComponent _jumpComponent;
        private IGroundRaycastComponent _groundRaycastComponent;

        [ShowInInspector]
        private IHealthComponent _healthComponent;
        

        private IConditionComponent _jumpCondition;
        private IConditionComponent _moveCondition;


        [Inject]
        public void Construct(
            IPlayerInput playerInput,
            IMoveComponent moveComponent,
            IFlipComponent flipComponent,
            IJumpComponent jumpComponent,
            IGroundRaycastComponent groundRaycastComponent,
            IHealthComponent healthComponent)
        {
            _playerInput = playerInput;
            _moveComponent = moveComponent;
            _flipComponent = flipComponent;
            _jumpComponent = jumpComponent;
            _groundRaycastComponent = groundRaycastComponent;
            _healthComponent = healthComponent;

            _jumpCondition = new ConditionComponent(() => _groundRaycastComponent.IsGrounded);
        }

        public void OnEnable()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
        }

        private void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }

        private void Move(Vector3 direction)
        {
            _flipComponent.LookTowards(direction);
            _moveComponent.SetDirection(direction);
        }

        private void Jump()
        {
            if (_jumpCondition.IsValid)
            {
                _jumpComponent.Jump();
            }
        }


        public void OnDisable()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
        }
    }
}