using System;

namespace Inventories
{
    public class InventoryController : IDisposable
    {
        private readonly Inventory _inventory;
        private readonly InventoryGrid _inventoryGrid;

        public InventoryController(Inventory inventory, InventoryGrid inventoryGrid)
        {
            _inventory = inventory;
            _inventoryGrid = inventoryGrid;

            _inventory.OnAdded += _inventoryGrid.AddItem;
            _inventory.OnRemoved += _inventoryGrid.RemoveItem;
            _inventory.OnMoved += _inventoryGrid.MoveItem;
            _inventory.OnCleared += _inventoryGrid.ClearGrid;
        }

        public void Dispose()
        {
            _inventory.OnAdded -= _inventoryGrid.AddItem;
            _inventory.OnRemoved -= _inventoryGrid.RemoveItem;
            _inventory.OnMoved -= _inventoryGrid.MoveItem;
            _inventory.OnCleared -= _inventoryGrid.ClearGrid;
        }
    }
}