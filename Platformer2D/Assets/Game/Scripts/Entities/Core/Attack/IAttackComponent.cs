namespace Game.Entities
{
    public interface IAttackComponent
    {
        void Attack(IHealthComponent target);
    }
}