using Game.Scripts.Game.Core.Conditions;
using Game.Scripts.Game.Core.Health;

namespace Game.Scripts.Game.Core.Attack
{
    public class AttackComponent : IAttackComponent
    {
        private readonly int _damage;

        public AttackComponent(int damage)
        {
            _damage = damage;
        }

        public void Attack(IHealthComponent target)
        {
            target.TakeDamage(_damage);
        }
    }
}