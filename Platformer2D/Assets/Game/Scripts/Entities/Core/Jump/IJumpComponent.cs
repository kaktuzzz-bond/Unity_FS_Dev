using Modules.Conditions;

namespace Game.Entities
{
    public interface IJumpComponent: ICompositeCondition
    {
        bool Jump();
        
    }
}