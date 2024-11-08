using Modules.Pooling;

namespace Gameplay.Spaceships
{
    public class EnemySpawner : PooledSpawner<Spaceship>
    {
       

        protected override void OnCreate(Spaceship item)
        {
          //item.Initialize(config.Create());
        }
    }
}