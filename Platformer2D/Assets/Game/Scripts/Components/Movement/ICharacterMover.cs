using Game.Scripts.Components.Conditions;

namespace Game.Scripts.Components.Movement
{
    public interface ICharacterMover : IConditionable
    {
        void MoveX(float direction);
    }
}