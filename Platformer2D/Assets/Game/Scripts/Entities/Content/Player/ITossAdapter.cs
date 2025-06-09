using System;

namespace Game.Entities
{
    public interface ITossAdapter
    {
        event Action OnToss;

        void Toss();
    }
}