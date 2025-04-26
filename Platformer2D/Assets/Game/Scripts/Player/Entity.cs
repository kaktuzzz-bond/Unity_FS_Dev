using Zenject;

namespace Game.Scripts.Player
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
    }
}