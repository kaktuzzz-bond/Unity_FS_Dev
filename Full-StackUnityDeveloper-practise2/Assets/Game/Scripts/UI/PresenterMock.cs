using Modules.Inventories;
using UnityEngine;

namespace SampleGame
{
    public class PresenterMock : IItemPresenter
    {
        public string Title { get; }
        public string Description { get; }
        public string Count { get; }
        public Sprite Icon { get; }
        public bool IsConsumable { get; }

        public PresenterMock(InventoryItem item, string count)
        {
            Title = item.Title;
            Description = item.Decription;
            Count = count;
            Icon = item.Icon;
            IsConsumable = item.IsConsumable;
        }

        public void Consume()
        {
            Debug.Log("Consume is invoked");
        }
    }
}