using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Modules.InputSystem
{
    public class InputAdapter : MonoBehaviour
    {
        public event Action<Vector2> OnMove;
        public event Action OnFirePressed;

        private PlayerInput _playerInput;

        private InputAction.CallbackContext _inputContext;

        private bool _isMoving;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Move.started += OnMoveStarted;
            _playerInput.Player.Move.canceled += OnMoveCanceled;
            _playerInput.Player.Attack.performed += OnAttackPressed;
        }

        private void OnMoveStarted(InputAction.CallbackContext ctx)
        {
            _isMoving = true;
        }

        private void OnMoveCanceled(InputAction.CallbackContext ctx)
        {
            _isMoving = false;
        }

        private void OnAttackPressed(InputAction.CallbackContext ctx)
        {
            OnFirePressed?.Invoke();
        }


        private void Update()
        {
            if (!_isMoving) return;

            OnMove?.Invoke(_playerInput.Player.Move.ReadValue<Vector2>());
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Move.started -= OnMoveStarted;
            _playerInput.Player.Move.canceled -= OnMoveCanceled;
            _playerInput.Player.Attack.performed -= OnAttackPressed;
        }
    }
}