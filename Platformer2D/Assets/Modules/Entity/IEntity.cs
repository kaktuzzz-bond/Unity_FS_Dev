namespace Game.Scripts.Components.Entity
{
    public interface IEntity
    {
        T Get<T>() where T : class;

        T TryGet<T>() where T : class;
        
        T Get<T>(object id) where T : class;

        T TryGet<T>(object id) where T : class;
    }
}