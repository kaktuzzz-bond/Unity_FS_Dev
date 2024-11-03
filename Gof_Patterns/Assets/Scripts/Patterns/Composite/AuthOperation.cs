using System.Threading.Tasks;

namespace Patterns.Composite
{
    public class AuthOperation : ILoadingOperation
    {
        private readonly AuthManager _authManager;

        public AuthOperation(AuthManager authManager)
        {
            _authManager = authManager;
        }

        public async Task<bool> Do()
        {
            return await _authManager.Authenticate();
        }
    }
}