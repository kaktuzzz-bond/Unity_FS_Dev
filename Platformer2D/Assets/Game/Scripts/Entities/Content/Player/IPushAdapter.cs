using System;

namespace Game.Entities
{
    public interface IPushAdapter
    {
        event Action OnPush;

        void Push();
    }
}