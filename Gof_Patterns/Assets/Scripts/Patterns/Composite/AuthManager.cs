using System.Threading.Tasks;

namespace Patterns.Composite
{
    public class AuthManager
    {
        public Task<bool> Authenticate()
        {
            return Task.FromResult(true);
        }
    }
}