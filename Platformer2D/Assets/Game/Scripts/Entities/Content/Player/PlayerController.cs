using System;
using Game.GameSystem;
using Modules;
using Zenject;

namespace Game.Entities
{
    public class PlayerController : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IEntity _player;

        public PlayerController(IPlayerInput playerInput, IEntity player)
        {
            _playerInput = playerInput;
            _player = player;
        }

        public void Initialize()
        {
            _playerInput.OnJumped += _player.Get<IJumpComponent>().Jump;
            _playerInput.OnMoved += _player.Get<IMoveComponent>().Move;
            _playerInput.OnPush += _player.Get<IPushAdapter>().Push;
            _playerInput.OnToss += _player.Get<ITossAdapter>().Toss;
        }


        public void Dispose()
        {
            _playerInput.OnJumped -= _player.Get<IJumpComponent>().Jump;
            _playerInput.OnMoved -= _player.Get<IMoveComponent>().Move;
            _playerInput.OnPush -= _player.Get<IPushAdapter>().Push;
            _playerInput.OnToss -= _player.Get<ITossAdapter>().Toss;
        }
    }
}