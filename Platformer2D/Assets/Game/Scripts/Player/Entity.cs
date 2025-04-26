using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class Entity : MonoBehaviour, IEntity
    {
        [SerializeField]
        private GameObjectContext context;

        public T Get<T>() where T : class
        {
            return context.Container.Resolve<T>();
        }
        
        public T TryGet<T>() where T : class
        {
            return context.Container.TryResolve<T>();
        }
    }
}