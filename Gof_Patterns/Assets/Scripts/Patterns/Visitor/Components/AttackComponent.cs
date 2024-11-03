using UnityEngine;

namespace Patterns.Visitor.Components
{
    public class AttackComponent : IVisitable
    {
        private int _damage;

        public void Attack(Transform target)
        {
        }

        public void Accept(IVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}