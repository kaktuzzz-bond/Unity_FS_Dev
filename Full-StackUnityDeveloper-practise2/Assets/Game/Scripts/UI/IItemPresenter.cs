using UnityEngine;

namespace SampleGame
{
    public interface IItemPresenter
    {
        string Title { get; }
        string Description { get; }
        string Count { get; }
        Sprite Icon { get; }
        bool IsConsumable { get; }
        
        void Consume();
    }
}