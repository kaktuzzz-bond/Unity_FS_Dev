using System.Collections.Generic;

namespace Game.App
{
    public interface IGameRepository
    {
        void SetState(Dictionary<string, string> gameState);

        Dictionary<string, string> GetState();
    }
}