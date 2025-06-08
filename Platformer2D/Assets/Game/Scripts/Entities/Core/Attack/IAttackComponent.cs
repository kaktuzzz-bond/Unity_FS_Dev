namespace Game.Entities
{
    public interface IAttackComponent
    {
        void Attack(IDamagable target);
    }
}