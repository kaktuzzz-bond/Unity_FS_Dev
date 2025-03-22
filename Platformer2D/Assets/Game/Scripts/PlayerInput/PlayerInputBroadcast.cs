using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Scripts.PlayerInput
{
    public class PlayerInputBroadcast : IInitializable, IDisposable, ITickable, IPlayerInput
    {
        public event Action<Vector3> OnMoved;
        public event Action OnJumped;


        private readonly PLayerInputMap _inputMap;

        private Vector3 _direction;

        public PlayerInputBroadcast(PLayerInputMap inputMap)
        {
            _inputMap = inputMap;
        }


        public void Initialize()
        {
            EnableInput();
            _inputMap.Keyboard.Jump.performed += OnJumpPressedHandler;
        }


        private void OnJumpPressedHandler(InputAction.CallbackContext ctx) =>
            OnJumped?.Invoke();

        public void EnableInput() =>
            _inputMap.Enable();

        public void DisableInput() =>
            _inputMap.Disable();

        public void Tick()
        {
            _direction.x = _inputMap.Keyboard.Move.ReadValue<float>();

            OnMoved?.Invoke(_direction);
        }

        public void Dispose()
        {
            DisableInput();
            _inputMap.Keyboard.Jump.performed -= OnJumpPressedHandler;
            _inputMap.Dispose();
        }
    }
}