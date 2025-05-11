using System;
using Game.Scripts.GameSystem.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Entities.Player
{
    public class PlayerController : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IPlayer _player;

        public PlayerController(IPlayerInput playerInput, IPlayer player)
        {
            _playerInput = playerInput;
            _player = player;
        }

        public void Initialize()
        {
            _playerInput.OnJumped += Jump;
            _playerInput.OnMoved += Move;
            _playerInput.OnPush += Push;
            _playerInput.OnToss += Toss;
        }

        private void Jump() => _player.Jump();

        private void Move(Vector2 direction) => _player.Move(direction);

        private void Push() => _player.Push();

        private void Toss() => _player.Toss();


        public void Dispose()
        {
            _playerInput.OnJumped -= Jump;
            _playerInput.OnMoved -= Move;
            _playerInput.OnPush -= Push;
            _playerInput.OnToss -= Toss;
        }
    }
}