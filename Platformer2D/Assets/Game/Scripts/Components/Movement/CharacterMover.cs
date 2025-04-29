using Game.Scripts.Components.Conditions;
using UnityEngine;

namespace Game.Scripts.Components.Movement
{
    public class CharacterMover : CompositeCondition, ICharacterMover
    {
        private readonly IMovable _moveUseCase;

        public CharacterMover(IMovable moveUseCase)
        {
            _moveUseCase = moveUseCase;
        }

        public Vector3 GetDirection => _moveUseCase.GetDirection;


        public void MoveX(float direction)
        {
            if (!IsValid) return;

            _moveUseCase.MoveX(direction);
        }
        
    }
}