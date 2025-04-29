using System;

namespace Game.Scripts.Components.Conditions
{
    public interface IConditionable
    {
        bool IsValid { get; }

        void AddCondition(Func<bool> condition);

        void RemoveCondition(Func<bool> condition);

    }
}