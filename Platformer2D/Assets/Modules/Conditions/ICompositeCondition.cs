using System;

namespace Modules.Conditions
{
    public interface ICompositeCondition
    {
        bool IsValid { get; }

        void AddCondition(Func<bool> condition);

        void RemoveCondition(Func<bool> condition);

    }
}