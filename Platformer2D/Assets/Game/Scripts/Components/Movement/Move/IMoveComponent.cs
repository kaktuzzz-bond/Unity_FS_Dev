using System;

namespace Game.Scripts.Components.Movement.Move
{
    public interface IMoveComponent: IMovable
    {
        void AddCondition(Func<bool> condition);
    }
}