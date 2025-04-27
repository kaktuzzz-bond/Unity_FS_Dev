namespace Game.Scripts.Components.Entities
{
    public interface IEntity
    {
        T Get<T>() where T : class;

        T TryGet<T>() where T : class;
    }
}