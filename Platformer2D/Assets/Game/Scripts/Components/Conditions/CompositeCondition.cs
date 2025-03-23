using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Scripts.Components.Conditions
{
    public class CompositeCondition
    {
        private readonly List<Func<bool>> _conditions;

        public CompositeCondition(params Func<bool>[] conditions)
        {
            _conditions = conditions.ToList();
        }

        public void Append(Func<bool> condition) => _conditions.Add(condition);

        public void Remove(Func<bool> condition) => _conditions.Remove(condition);

        public bool IsValid => _conditions.All(condition => condition.Invoke());
    }
}