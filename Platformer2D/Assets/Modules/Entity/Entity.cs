using Zenject;

namespace Game.Scripts.Components.Entity
{
    public class Entity : IEntity
    {
        private readonly DiContainer _container;

        public Entity(DiContainer container)
        {
            _container = container;
        }

        public T Get<T>() where T : class => _container.Resolve<T>();

        public T TryGet<T>() where T : class => _container.TryResolve<T>();
        
        public T Get<T>(object id) where T : class => _container.ResolveId<T>(id);

        public T TryGet<T>(object id) where T : class => _container.TryResolveId<T>(id);
    }
}