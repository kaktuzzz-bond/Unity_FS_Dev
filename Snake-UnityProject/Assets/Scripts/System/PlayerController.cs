using Modules;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class PlayerController : ITickable
    {
        private readonly IPlayerInput _playerInput;
        private readonly ISnake _player;


        public PlayerController(IPlayerInput playerInput, ISnake player)
        {
            _playerInput = playerInput;
            _player = player;
        }


        public void Tick()
        {
            Debug.Log("Tick");
            _player.Turn(_playerInput.GetDirection());
        }
    }
}