using Zenject;

namespace Modules
{
    public class Entity : IEntity
    {
        private readonly DiContainer _container;

        public Entity(DiContainer container)
        {
            _container = container;
        }

        public T Get<T>() where T : class => _container.Resolve<T>();
        public T Get<T>(object id) where T : class => _container.ResolveId<T>(id);
        
        public bool TryGet<T>(out T component) where T : class
        {
            component = _container.TryResolve<T>();
            return component != null;
        }
        
        public bool TryGet<T>(object id, out T component) where T : class
        {
            component = _container.TryResolveId<T>(id);
            return component != null;
        }
    }
}