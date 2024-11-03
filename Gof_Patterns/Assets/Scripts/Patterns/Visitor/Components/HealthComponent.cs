using UnityEngine;

namespace Patterns.Visitor.Components
{
    public class HealthComponent : IVisitable
    {
        private int _health;
        private bool _isGodMode;

        public void TakeDamage()
        {
        }
        public void Accept(IVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}