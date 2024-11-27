using System;
using UnityEngine;

namespace SampleGame
{
    public interface IItemPresenter
    {
        
        event Action OnStateShanged;
        string Title { get; }
        string Description { get; }
        string Count { get; }
        Sprite Icon { get; }
        bool IsConsumable { get; }
        
        void Consume();
    }
}