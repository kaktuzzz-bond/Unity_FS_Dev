using System;
using Game.Scripts.Components.Conditions;

namespace Game.Scripts.Components.Jump
{
    public interface IJumpComponent : IJumpable
    {
        void AddCondition(Func<bool> condition);
    }
}