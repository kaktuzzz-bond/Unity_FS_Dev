using Game.Scripts.Components.Health;

namespace Game.Scripts.Components.Attack
{
    public class AttackUseCase : IAttackable
    {
        private readonly int _damage;

        public AttackUseCase(int damage)
        {
            _damage = damage;
        }

        public void Attack(IDamagableBody target)
        {
            target.TakeDamage(_damage);
        }
    }
}