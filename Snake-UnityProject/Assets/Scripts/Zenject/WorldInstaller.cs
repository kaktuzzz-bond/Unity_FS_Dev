using SnakeGame;
using UnityEngine;

namespace Zenject
{
    public class WorldInstaller:MonoInstaller<WorldInstaller>
    {
        [SerializeField]
        private WorldBounds _worldBounds;
        public override void InstallBindings()
        {
            Container.Bind<IWorldBounds>()
                     .To<WorldBounds>()
                     .FromInstance(_worldBounds)
                     .AsSingle();
        }
    }
}