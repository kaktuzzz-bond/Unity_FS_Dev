using System;
using Game.Entities;
using Modules;
using UnityEngine;

namespace Game.GameSystem
{
    public class CharacterController : IDisposable, ICharacterController
    {
        private readonly IPlayerInput _playerInput;
        private IEntity _entity;

        public CharacterController(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void SetEntity(IEntity entity)
        {
            if (_entity != null)
                Dispose();

            _entity = entity;

            _playerInput.OnJumped += _entity.Get<IJumpComponent>().Jump;
            _playerInput.OnMoved += _entity.Get<IMoveComponent>().Move;
            _playerInput.OnPush += _entity.Get<IPushAdapter>().Push;
            _playerInput.OnToss += _entity.Get<ITossAdapter>().Toss;
        }

        public void Dispose()
        {
            _playerInput.OnJumped -= _entity.Get<IJumpComponent>().Jump;
            _playerInput.OnMoved -= _entity.Get<IMoveComponent>().Move;
            _playerInput.OnPush -= _entity.Get<IPushAdapter>().Push;
            _playerInput.OnToss -= _entity.Get<ITossAdapter>().Toss;
        }
    }
}