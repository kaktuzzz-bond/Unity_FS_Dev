using UnityEngine;

namespace Patterns.Adapter.Craft
{
    public class ItemCrafter
    {
        private readonly IInventoryAdapter _inventoryAdapter;

        public ItemCrafter(IInventoryAdapter inventoryAdapter)
        {
            _inventoryAdapter = inventoryAdapter;
        }

        public void Craft(string itemName)
        {
            var capacity = GetCapacity();
            _inventoryAdapter.AddItem(itemName, capacity);
        }

        private int GetCapacity()
        {
            return Random.Range(1, 10);
        }
    }
}