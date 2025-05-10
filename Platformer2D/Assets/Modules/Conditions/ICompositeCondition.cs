using System;

namespace Game.Scripts.Game.Core.Conditions
{
    public interface ICompositeCondition
    {
        bool IsValid { get; }

        void AddCondition(Func<bool> condition);

        void RemoveCondition(Func<bool> condition);

    }
}