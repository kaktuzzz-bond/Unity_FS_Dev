using Game.Scripts.Game.Core.Health;

namespace Game.Scripts.Game.Core.Attack
{
    public interface IAttackComponent
    {
        void Attack(IHealthComponent target);
    }
}