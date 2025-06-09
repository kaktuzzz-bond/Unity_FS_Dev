using System;
using Modules;

namespace Game.Entities
{
    public interface IJumpComponent: ICompositeCondition
    {
        event Action OnJump;
        void Jump();
        
    }
}