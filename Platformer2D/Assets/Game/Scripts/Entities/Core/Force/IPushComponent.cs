namespace Game.Entities
{
    public interface IPushComponent
    {
        void Push(IPushableComponent pushable);

        void PushOpposite(IPushableComponent pushable);
    }
}