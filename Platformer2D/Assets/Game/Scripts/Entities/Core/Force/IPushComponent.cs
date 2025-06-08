using UnityEngine;

namespace Game.Entities
{
    public interface IPushComponent
    {
        void Push(IPushable pushable);
        bool Push();
    }
}