namespace Patterns.Decorator
{
    public interface IMoneyStorage
    {
        void Earn(int amount);
        void Spend(int amount);
    }
}