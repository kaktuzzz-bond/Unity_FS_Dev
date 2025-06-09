using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace Game.GameSystem
{
    public class PlayerInputBroadcaster : IPlayerInput, IInitializable, IDisposable
    {
        public event Action<Vector2> OnMoved;
        public event Action OnJumped;
        public event Action OnPush;
        public event Action OnToss;


        private readonly PLayerInputMap _inputMap;

        private Vector2 _direction;
        private bool _isMoving;

        private readonly CancellationTokenSource _cts = new();

        public PlayerInputBroadcaster(PLayerInputMap inputMap)
        {
            _inputMap = inputMap;
        }

        public void Initialize()
        {
            EnableInput();
            _inputMap.Keyboard.Jump.performed += OnJumpPressed;
            _inputMap.Keyboard.Push.performed += OnPushPressed;
            _inputMap.Keyboard.Toss.performed += OnTossPressed;
            _inputMap.Keyboard.Move.started += OnMoveStarted;
            _inputMap.Keyboard.Move.canceled += OnMoveCancelled;
        }

        public void EnableInput() => _inputMap.Enable();

        public void DisableInput() => _inputMap.Disable();


        private void OnMoveStarted(CallbackContext ctx)
        {
            _isMoving = true;
            MoveAsync().Forget();
        }

        private async UniTaskVoid MoveAsync()
        {
            while (_isMoving)
            {
                _direction.x = _inputMap.Keyboard.Move.ReadValue<float>();
                OnMoved?.Invoke(_direction);

                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: _cts.Token);
            }
        }

        private void OnMoveCancelled(CallbackContext ctx)
        {
            _isMoving = false;
            _direction.x = 0f;
            OnMoved?.Invoke(_direction);
        }

        private void OnJumpPressed(CallbackContext ctx) => OnJumped?.Invoke();

        private void OnPushPressed(CallbackContext ctx) => OnPush?.Invoke();

        private void OnTossPressed(CallbackContext ctx) => OnToss?.Invoke();

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            DisableInput();
            _inputMap.Keyboard.Jump.performed -= OnJumpPressed;
            _inputMap.Keyboard.Push.performed -= OnPushPressed;
            _inputMap.Keyboard.Toss.performed -= OnTossPressed;
            _inputMap.Keyboard.Move.started -= OnMoveStarted;
            _inputMap.Keyboard.Move.canceled -= OnMoveCancelled;
            _inputMap.Dispose();
        }
    }
}