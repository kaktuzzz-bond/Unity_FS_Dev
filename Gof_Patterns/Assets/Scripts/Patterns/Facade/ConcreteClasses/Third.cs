using Patterns.Facade.Services;

namespace Patterns.Facade.ConcreteClasses
{
    public class Third
    {
        public Third(
            IClientService clientService,
            IInputService inputService,
            INetworkService networkService,
            IOneMoreService oneMoreService)
        {
        }
    }
}