using System;

namespace Modules
{
    public interface IEntityProxy
    {
        IEntity Entity { get; }

        event Action<IEntity> OnTriggerEnter;
        event Action<IEntity> OnTriggerExit;
    }
}