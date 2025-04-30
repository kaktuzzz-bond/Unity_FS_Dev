using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class CharacterJumper : CompositeCondition, IInitializable, ICharacterJumper
    {
        private readonly IJumpable _jumpUseCase;
       
        [ShowInInspector, ReadOnly]
        private readonly ICooldownTimer _timer;

        public CharacterJumper(IJumpable jumpUseCase, ICooldownTimer timer)
        {
            _jumpUseCase = jumpUseCase;
            _timer = timer;
        }

        public void Initialize()
        {
            AddCondition(() => !_timer.IsInProgress);
        }
        

        public void Jump(Action onJump)
        {
            if (!IsValid) return;

            _jumpUseCase.Jump();
            _timer.Launch();
            
            onJump?.Invoke();
        }
        
    }
}