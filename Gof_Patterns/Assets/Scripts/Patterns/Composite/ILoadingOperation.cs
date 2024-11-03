using System.Threading.Tasks;

namespace Patterns.Composite
{
    public interface ILoadingOperation
    {
        Task<bool> Do();
    }
}