using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Game.Scripts.Components.Conditions
{
    public class CompositeCondition : ICondition
    {
        [ShowInInspector]
        private readonly List<Func<bool>> _conditions;

        public CompositeCondition(params Func<bool>[] conditions)
        {
            _conditions = conditions.ToList();
        }

        public void AddCondition(Func<bool> condition) => _conditions.Add(condition);

        public void RemoveCondition(Func<bool> condition) => _conditions.Remove(condition);

        public bool IsValid => _conditions.All(condition => condition.Invoke());
    }
}