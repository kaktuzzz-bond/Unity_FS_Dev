using Game.Scripts.Components.Attack;
using Game.Scripts.Components.Health;

namespace Game.Scripts.Enemies.Lava
{
    public class Lava : ILava
    {
        private readonly IAttackable _attackComponent;

        public Lava(IAttackable attackComponent)
        {
            _attackComponent = attackComponent;
        }

        public void Attack(IDamagable target) => _attackComponent.Attack(target);
    }
}