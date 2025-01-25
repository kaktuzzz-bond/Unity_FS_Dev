using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Scripts.PlayerInput
{
    public interface IPlayerInput
    {
        event Action<Vector2> OnMovePressed;
        event Action OnJumpPressed;
    }


    public class PlayerInputHandler : IInitializable, IDisposable, ITickable, IPlayerInput
    {
        public event Action<Vector2> OnMovePressed;
        public event Action OnJumpPressed;

        private readonly PLayerInputMap _inputMap;

        private Vector2 _direction;

        public PlayerInputHandler(PLayerInputMap inputMap)
        {
            _inputMap = inputMap;

        }


        public void Initialize()
        {
            _inputMap.Enable();

            _inputMap.Keyboard.Jump.performed += OnJumpPressedHandler;
        }


        private void OnJumpPressedHandler(InputAction.CallbackContext ctx)
        {
            OnJumpPressed?.Invoke();
        }


        public void Tick()
        {
            _direction = _inputMap.Keyboard.Move.ReadValue<Vector2>();

            if (_direction == Vector2.zero) return;

            OnMovePressed?.Invoke(_direction);
        }

        public void Dispose()
        {

            _inputMap.Keyboard.Jump.performed -= OnJumpPressedHandler;

            _inputMap.Disable();

            _inputMap.Dispose();
        }
    }
}