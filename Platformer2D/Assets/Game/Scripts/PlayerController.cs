using System;
using Game.Scripts.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    public class PlayerController : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;

        public PlayerController(IPlayerInput playerInput)
        {
            _playerInput = playerInput;

        }

        public void Initialize()
        {
            _playerInput.OnJumpPressed += Jump;
            _playerInput.OnMovePressed += Move;
        }

        private void Move(Vector2 direction)
        {
            Debug.Log($"Move: {direction}");
        }

        private void Jump()
        {
            Debug.Log("Jump");
        }

        public void Dispose()
        {
            _playerInput.OnJumpPressed -= Jump;
            _playerInput.OnMovePressed -= Move;
        }
    }
}