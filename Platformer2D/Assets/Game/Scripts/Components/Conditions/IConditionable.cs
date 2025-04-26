using System;

namespace Game.Scripts.Components.Conditions
{
    public interface IConditionable
    {
        void AddCondition(Func<bool> condition);
    }
}