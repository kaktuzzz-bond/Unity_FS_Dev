using Game.Scripts.Components;
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
        private IFlipComponent _flipComponent;

        private IConditionComponent _jumpCondition;
        private IConditionComponent _moveCondition;


        [Inject]
        public void Construct(IPlayerInput playerInput,
            IMoveComponent moveComponent,
            IFlipComponent flipComponent,
            IJumpComponent jumpComponent,
            IGroundRaycastComponent groundRaycastComponent)
        {
            _playerInput = playerInput;
            _moveComponent = moveComponent;
            _flipComponent = flipComponent;
            _jumpComponent = jumpComponent;
            _groundRaycastComponent = groundRaycastComponent;

            _jumpCondition = new ConditionComponent(() => _groundRaycastComponent.IsGrounded);
        }

        public void OnEnable()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
        }

        private void Move(Vector3 direction)
        {
            _flipComponent.LookTowards(direction);
            _moveComponent.Move(direction);
        }

        private void Jump()
        {
            if (!_jumpCondition.IsValid) return;

            _jumpComponent.Jump();
        }


        public void OnDisable()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
        }
    }
}