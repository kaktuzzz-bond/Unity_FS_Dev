using System;
using System.Collections.Generic;
using Modules.Inventories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.Inventories
{
    //Нельзя менять!
    //Использует предметы игрока в инвентаре
    public sealed class InventoryItemConsumer
    {
        public event Action<InventoryItem> OnItemConsumed;

        private readonly Inventory inventory;
        private readonly Dictionary<InventoryItem, IHandler> _handlers = new();

        public InventoryItemConsumer(Inventory inventory) => 
            this.inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));

        [Button]
        public bool CanConsume(InventoryItem item) => 
            item != null && item.IsConsumable && this.inventory.HasItem(item);

        [Button]
        public bool Consume(InventoryItem item)
        {
            if (!this.CanConsume(item))
                return false;
            
            this.inventory.RemoveItem(item);
            if (_handlers.TryGetValue(item, out IHandler handler)) 
                handler.ProcessConsume(item);
            
            this.OnItemConsumed?.Invoke(item);
            return true;
        }

        public void AddHandler(InventoryItem item, IHandler handler)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            _handlers.Add(item, handler);
        }
        
        public void RemoveHandler(InventoryItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            
            _handlers.Remove(item);
        }
        
        public interface IHandler
        {
            void ProcessConsume(InventoryItem item);
        }
    }
}