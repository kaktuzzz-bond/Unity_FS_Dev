using Patterns.Visitor.Components;

namespace Patterns.Visitor
{
    public interface IVisitor
    {
        void Visit(MoveComponent moveComponent);
        void Visit(AttackComponent attackComponent);
        void Visit(HealthComponent healthComponent);
    }
}