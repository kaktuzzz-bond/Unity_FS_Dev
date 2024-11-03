using UnityEngine;

namespace Patterns.Visitor.Components
{
    public class MoveComponent : IVisitable
    {
        private float _speed;

        
        public void Move(Vector3 to)
        {
        }

        public void Accept(IVisitor visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}