using Patterns.Facade.Services;

namespace Patterns.Facade.ConcreteClasses
{
    public class First
    {
        public First(
            IClientService clientService,
            IInputService inputService,
            INetworkService networkService,
            IOneMoreService oneMoreService)
        {
        }
    }
}