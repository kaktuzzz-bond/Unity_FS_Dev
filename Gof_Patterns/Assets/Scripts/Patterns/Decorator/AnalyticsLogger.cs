using UnityEngine;

namespace Patterns.Decorator
{
    public class AnalyticsLogger
    {
        public void LogMoneyEvent(int money, MoneyAction moneyAction)
        {
            Debug.Log($"Money event: {money}, Action: {moneyAction}");
        }
    }
}