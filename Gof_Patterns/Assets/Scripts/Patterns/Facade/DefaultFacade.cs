using System;
using Patterns.Facade.Services;
using UnityEngine;

namespace Patterns.Facade
{
    public class DefaultFacade : IFacade
    {
        public event Action<Vector2> OnInput;
        public int ClientId => _clientService.ClientId;
        public bool IsConnectedToNetwork => _networkService.IsConnected;

        private readonly IClientService _clientService;
        private readonly IInputService _inputService;
        private readonly INetworkService _networkService;
        private readonly IOneMoreService _oneMoreService;

        public DefaultFacade(
            IClientService clientService,
            IInputService inputService,
            INetworkService networkService,
            IOneMoreService oneMoreService)
        {
            _clientService = clientService;
            _inputService = inputService;
            _networkService = networkService;
            _oneMoreService = oneMoreService;

            _inputService.OnInput += OnInputHandler;
        }
        
        public void DoVeryUsefulThing()
        {
            _oneMoreService.DoSomething();
        }

        private void OnInputHandler(Vector2 position)
        {
            OnInput?.Invoke(Vector2.zero);
        }
    }
}