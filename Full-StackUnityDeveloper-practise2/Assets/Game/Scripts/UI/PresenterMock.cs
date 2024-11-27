using System;
using ModestTree.Util;
using Modules.Inventories;
using UnityEngine;

namespace SampleGame
{
    public class PresenterMock : IItemPresenter
    {
        private readonly InventoryItem _item;
        private readonly Inventory _inventory;
        private readonly InventoryItemConsumer _consumer;
        public event Action OnStateShanged;
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Count { get; private set; }
        public Sprite Icon { get; private set; }
        public bool IsConsumable { get; private set; }


        public PresenterMock(InventoryItem item, Inventory inventory, InventoryItemConsumer consumer)
        {
            _item = item;
            _inventory = inventory;
            _consumer = consumer;
            Title = item.Title;
            Description = item.Decription;
            Icon = item.Icon;
            IsConsumable = item.IsConsumable;
        }


        public void SetItem(InventoryItem item)
        {
            Title = item.Title;
            Description = item.Decription;
            Count = _inventory.GetCount(item).ToString();
            Icon = item.Icon;
            IsConsumable = item.IsConsumable;

            OnStateShanged?.Invoke();
        }


        public void Consume()
        {
            _consumer.Consume(_item);
        }
    }
}