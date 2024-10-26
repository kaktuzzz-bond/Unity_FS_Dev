using System;

namespace Modules.Pooling
{
    public interface IPoolReleasable<out T>
    {
        public Action<T> OnRelease { set; }

        public void SetReleaseAction(Action<T> action);
    }
}