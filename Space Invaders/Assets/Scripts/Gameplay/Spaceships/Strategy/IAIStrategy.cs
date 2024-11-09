using UnityEngine;

namespace Gameplay.Spaceships.Strategy
{
    public interface IAIStrategy
    {
        void Update(Vector2 direction);
    }
}