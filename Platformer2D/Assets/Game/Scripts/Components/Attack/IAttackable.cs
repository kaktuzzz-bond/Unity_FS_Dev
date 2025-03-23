using Game.Scripts.Components.Health;

namespace Game.Scripts.Components.Attack
{
    public interface IAttackable
    {
        void Attack(IDamagable target);
    }
}