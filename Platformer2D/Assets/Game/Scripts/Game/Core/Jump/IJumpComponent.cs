using Game.Scripts.Game.Core.Conditions;

namespace Game.Scripts.Game.Core.Jump
{
    public interface IJumpComponent: ICompositeCondition
    {
        bool Jump();
        
    }
}