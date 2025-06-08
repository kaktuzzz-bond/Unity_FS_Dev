using Modules;

namespace Game.Entities
{
    public interface IJumpComponent: ICompositeCondition
    {
        bool Jump();
        
    }
}