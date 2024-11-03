using System;
using System.Threading.Tasks;



namespace Patterns.Composite
{
    public class LoadingOperationSequence:ILoadingOperation
    {
        private readonly ILoadingOperation[] _operations;

        public LoadingOperationSequence(ILoadingOperation[] operations)
        {
            _operations = operations;
        }
        public Task<bool> Do()
        {
            // foreach (var operation in _operations)
            // {
            //     if (!await operation.Do()) return false;
            //     
            //     Task.FromResult(true);
            // }
            return Task.FromResult(true);
        }
    }
}