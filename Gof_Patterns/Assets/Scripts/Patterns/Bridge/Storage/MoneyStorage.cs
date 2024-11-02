namespace Patterns.Bridge.Storage
{
    public class MoneyStorage
    {
        private int _moneyCounter;

        public void AddMoney(int amount)
        {
            _moneyCounter += amount;
        }
    }
}