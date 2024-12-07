using System;

namespace Modules.Score
{
    //Don't modify
    public interface IScore
    {
        event Action<int> OnStateChanged;
        
        int Current { get; }
        void Add(int amount);
    }
}