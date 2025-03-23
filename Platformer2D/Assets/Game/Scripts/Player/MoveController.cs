using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Flip;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class MoveController : MonoBehaviour
    {
        private IPlayerInput _playerInput;
        private IMoveComponent _moveComponent;
        private IFlipComponent _flipComponent;
        private IJumpComponent _jumpComponent;
        private IGroundRaycastSensor _groundRaycastSensor;

        private IConditionComponent _jumpCondition;
        private IConditionComponent _moveCondition;

        [Inject]
        public void Construct(
            IPlayerInput playerInput,
            IMoveComponent moveComponent,
            IFlipComponent flipComponent,
            IJumpComponent jumpComponent,
            IGroundRaycastSensor groundRaycastSensor)
        {
            _playerInput = playerInput;
            _moveComponent = moveComponent;
            _flipComponent = flipComponent;
            _jumpComponent = jumpComponent;
            _groundRaycastSensor = groundRaycastSensor;

            _jumpCondition = new ConditionComponent(() => _groundRaycastSensor.IsGrounded);
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