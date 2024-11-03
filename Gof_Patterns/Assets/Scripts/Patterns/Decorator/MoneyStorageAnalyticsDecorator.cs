namespace Patterns.Decorator
{
    public class MoneyStorageAnalyticsDecorator:IMoneyStorage
    {
       private  readonly IMoneyStorage _storage;
       private readonly AnalyticsLogger _analyticsLogger;

       public MoneyStorageAnalyticsDecorator(IMoneyStorage moneyStorage, AnalyticsLogger analyticsLogger)
       {
           _storage = moneyStorage;
           _analyticsLogger = analyticsLogger;
       }
        public void Earn(int amount)
        {
           _storage.Earn(amount);
           _analyticsLogger.LogMoneyEvent(amount, MoneyAction.Income);
        }

        public void Spend(int amount)
        {
            _storage.Earn(amount);
            _analyticsLogger.LogMoneyEvent(amount, MoneyAction.Spending);
        }
    }
}