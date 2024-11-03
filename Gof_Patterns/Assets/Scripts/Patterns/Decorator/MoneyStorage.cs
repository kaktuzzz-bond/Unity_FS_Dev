namespace Patterns.Decorator
{
    public class MoneyStorage : IMoneyStorage
    {
        private int _money;
        public void Earn(int amount)
        {
            _money += amount;
        }

        public void Spend(int amount)
        {
            _money -= amount;
        }
    }
}