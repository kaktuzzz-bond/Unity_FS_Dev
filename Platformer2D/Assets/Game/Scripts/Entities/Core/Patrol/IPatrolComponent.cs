using Modules;

namespace Game.Entities
{
    public interface IPatrolComponent:ICompositeCondition
    {
        void Pause();
    }
}