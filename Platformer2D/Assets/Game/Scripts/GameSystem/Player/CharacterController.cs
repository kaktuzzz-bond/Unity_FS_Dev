using System;
using Game.Entities;
using Modules;
using Zenject;

namespace Game.GameSystem
{
    public class CharacterController : IInitializable, IDisposable
    {
        private readonly IPlayerInput _playerInput;
        private readonly IEntity _player;

        public CharacterController(IPlayerInput playerInput, IEntity player)
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