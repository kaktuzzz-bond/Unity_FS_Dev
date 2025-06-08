namespace Modules
{
    public interface IEntity
    {
        T Get<T>() where T : class;

        T Get<T>(object id) where T : class;

        public bool TryGet<T>(out T component) where T : class;

        public bool TryGet<T>(object id, out T component) where T : class;
    }
}