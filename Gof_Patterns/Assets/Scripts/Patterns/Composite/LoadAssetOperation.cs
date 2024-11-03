using System.Threading.Tasks;
using UnityEngine;

namespace Patterns.Composite
{
    public class LoadAssetOperation : ILoadingOperation
    {
        private string _assetName;

        public Task<bool> Do()
        {
          // return Resources.LoadAsync<bool>(_assetName).isDone;
           return Task.FromResult(true);
        }
    }
}