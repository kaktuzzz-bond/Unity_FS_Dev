using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Player;
using Game.Scripts.Player.Settings;
using Zenject;

namespace Game.Scripts.Components.Jump
{
    public class JumpValidator : IInitializable
    {
        private readonly IEntity _entity;

        private CompositeCondition _jumpCondition;
        private CooldownTimer _jumpCooldown;

        public JumpValidator(IEntity entity)
        {
            _entity = entity;
        }

        public void Initialize()
        {
            var healthComponent = _entity.Get<IHealthComponent>();
            var groundSensor = _entity.Get<IGroundRaycastSensor>();
            var jumpSettings = _entity.Get<JumpSettings>();

            _jumpCooldown = jumpSettings.CreateTimer;

            _jumpCondition = new CompositeCondition(
                () => groundSensor.IsGrounded,
                () => healthComponent.IsAlive,
                () => !_jumpCooldown.IsInProgress);
        }

        public bool Jump()
        {
            if (!_jumpCondition.IsValid) return false;

            _jumpCooldown.Launch();

            return true;
        }
    }
}