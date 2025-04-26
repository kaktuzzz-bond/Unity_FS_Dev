using System;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace Game.Scripts.PlayerInput
{
    public class PlayerInputBroadcaster : IInitializable, IDisposable, ITickable, IPlayerInput
    {
        public event Action<Vector3> OnMoved;
        public event Action OnJumped;


        private readonly PLayerInputMap _inputMap;

        private Vector3 _direction;

        public PlayerInputBroadcaster(PLayerInputMap inputMap)
        {
            _inputMap = inputMap;
        }


        public void Initialize()
        {
            EnableInput();
            _inputMap.Keyboard.Jump.performed += OnJumpPressed;
        }

        public void EnableInput() => _inputMap.Enable();

        public void DisableInput() => _inputMap.Disable();


        private void OnJumpPressed(CallbackContext ctx) => OnJumped?.Invoke();


        public void Tick()
        {
            _direction.x = _inputMap.Keyboard.Move.ReadValue<float>();
            OnMoved?.Invoke(_direction);
        }

        public void Dispose()
        {
            DisableInput();
            _inputMap.Keyboard.Jump.performed -= OnJumpPressed;
            _inputMap.Dispose();
        }
    }
}