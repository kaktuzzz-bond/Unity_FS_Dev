using Game.Scripts.Components;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.GroundDetection;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Move;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Character : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IMoveComponent _moveComponent;
        private IJumpComponent _jumpComponent;
        private IGroundRaycastComponent _groundRaycastComponent;


        private IConditionComponent _jumpCondition;
        private IConditionComponent _moveCondition;


        [Inject]
        public void Construct(IPlayerInput playerInput,
            IMoveComponent moveComponent,
            IJumpComponent jumpComponent,
            IGroundRaycastComponent groundRaycastComponent)
        {
            _playerInput = playerInput;
            _moveComponent = moveComponent;
            _jumpComponent = jumpComponent;
            _groundRaycastComponent = groundRaycastComponent;

            _jumpCondition = new ConditionComponent(()=> _groundRaycastComponent.IsGrounded);
        }

        public void OnEnable()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
        }

        private void Move(Vector3 direction)
        {
            _moveComponent.Move(direction);
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