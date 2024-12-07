using System;

namespace Modules.Difficulty
{
    //Don't modify
    public interface IDifficulty
    {
        event Action OnStateChanged; 
        
        int Current { get; }
        int Max { get; }
        bool Next(out int difficulty);
    }
}