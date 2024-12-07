using System;
using Modules.Snake;

namespace Loop
{
    public interface IDeathObserver
    {
        event Action OnDeath;
        
        void StartObserving(ISnake snake);
        void CancelObserving();
    }
}