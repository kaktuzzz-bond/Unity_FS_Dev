using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Patterns.Composite
{
    public class LoadSceneOperation : ILoadingOperation
    {
        private string _sceneName;

        public Task<bool> Do()
        {
            var scene = SceneManager.LoadSceneAsync(_sceneName);
            //wait for loading
            return Task.FromResult(scene.isDone);
        }
    }
}