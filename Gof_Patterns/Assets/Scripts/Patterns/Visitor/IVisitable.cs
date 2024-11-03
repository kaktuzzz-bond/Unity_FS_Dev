namespace Patterns.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}