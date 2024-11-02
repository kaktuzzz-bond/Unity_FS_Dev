using Patterns.Facade.Services;

namespace Patterns.Facade.ConcreteClasses
{
    public class Second
    {
        public Second(
            IClientService clientService,
            IInputService inputService,
            INetworkService networkService,
            IOneMoreService oneMoreService)
        {
        }
    }
}