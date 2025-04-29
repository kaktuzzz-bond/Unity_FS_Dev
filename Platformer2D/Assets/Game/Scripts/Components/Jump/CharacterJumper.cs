using System;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Sensors;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class CharacterJumper : CompositeCondition, ICharacterJumper, IInitializable
    {
        private readonly IJumpable _jumpUseCase;
        private readonly IGroundRaycastSensor _groundSensor;

        [ShowInInspector, ReadOnly]
        private readonly ICooldownTimer _timer;

        public CharacterJumper(IJumpable jumpUseCase, IGroundRaycastSensor groundSensor, ICooldownTimer timer)
        {
            _jumpUseCase = jumpUseCase;
            _groundSensor = groundSensor;
            _timer = timer;
        }

        public void Initialize()
        {
            AddCondition(() => !_timer.IsInProgress);
            AddCondition(() => _groundSensor.IsGrounded);
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