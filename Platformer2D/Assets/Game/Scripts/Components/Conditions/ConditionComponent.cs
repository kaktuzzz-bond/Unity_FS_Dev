using System;
using System.Linq;

namespace Game.Scripts.Components.Conditions
{
    public class ConditionComponent : IConditionComponent
    {
        private readonly Func<bool>[] _conditions;

        public ConditionComponent(params Func<bool>[] conditions)
        {
            _conditions = conditions ?? throw new ArgumentNullException("Conditions cannot be null");
        }

        public bool IsValid =>
            _conditions.All(condition => condition.Invoke());
    }
}