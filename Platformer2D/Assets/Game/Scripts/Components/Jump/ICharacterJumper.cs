using System;
using Game.Scripts.Components.Conditions;

namespace Game.Scripts.Components.Jump
{
    public interface ICharacterJumper :IConditionable
    {
        void Jump(Action onJump);
    }
}