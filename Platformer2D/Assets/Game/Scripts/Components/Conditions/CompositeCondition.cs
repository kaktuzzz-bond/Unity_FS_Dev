using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Game.Scripts.Components.Conditions
{
    public abstract class CompositeCondition : IConditionable
    {
        [ShowInInspector, ReadOnly]
        private readonly List<Func<bool>> _conditions = new();
        
        [ShowInInspector, ReadOnly]
        public bool IsValid => _conditions.All(condition => condition.Invoke());
        
        public void AddCondition(Func<bool> condition) => _conditions.Add(condition);

        public void RemoveCondition(Func<bool> condition) => _conditions.Remove(condition);

     
    }
}