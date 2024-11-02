using Patterns.Adapter.Craft;
using UnityEngine;

namespace Patterns.Adapter.Inventory
{
    public class InventoryAdapter : IInventoryAdapter
    {
        private readonly GridInventory _inventory;
        private Item _exampleItem;

        public InventoryAdapter(GridInventory inventory)
        {
            _inventory = inventory;
        }

        public void AddItem(string itemName, int capacity)
        {
            _exampleItem = new Item(itemName, capacity);
            _inventory.AddItem(_exampleItem, Vector2Int.zero);
        }

        public void RemoveItem(string itemName, int capacity)
        {
            _inventory.RemoveItem(_exampleItem);
        }
    }
}