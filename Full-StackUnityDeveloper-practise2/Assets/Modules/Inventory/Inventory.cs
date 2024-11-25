using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.Inventories
{
    //Нельзя менять!
    public sealed class Inventory
    {
        public event Action<Cell> OnAdded;
        public event Action<Cell> OnRemoved;

        [ShowInInspector]
        private readonly Dictionary<InventoryItem, Cell> items = new();

        public Inventory(params Cell[] cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            for (int i = 0, length = cells.Length; i < length; i++)
            {
                Cell cell = cells[i];
                if (cell is {Count: > 0})
                    this.items[cell.Item] = new Cell(cell);
            }
        }

        public Inventory(params KeyValuePair<InventoryItem, int>[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            for (int i = 0, length = items.Length; i < length; i++)
            {
                KeyValuePair<InventoryItem, int> item = items[i];
                if (item.Value > 0)
                    this.items[item.Key] = new Cell(item);
            }
        }

        [Button]
        public bool AddItems(InventoryItem item, int range)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (range < 0)
                throw new ArgumentOutOfRangeException(nameof(range));

            if (range == 0)
                return false;

            if (this.items.TryGetValue(item, out Cell cell))
            {
                cell.Count += range;
                return true;
            }

            cell = new Cell(item, range);
            this.items.Add(item, cell);
            this.OnAdded?.Invoke(cell);
            return true;
        }

        public bool RemoveItem(InventoryItem item) =>
            this.RemoveItems(item, 1);

        [Button]
        public bool RemoveItems(InventoryItem item, int range)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (range < 0)
                throw new ArgumentOutOfRangeException(nameof(range));

            if (range == 0)
                return false;

            if (!this.items.TryGetValue(item, out Cell cell))
                return false;

            if (cell.Count < range)
                return false;

            cell.Count -= range;
            if (cell.Count > 0)
                return true;

            this.items.Remove(cell.Item);
            this.OnRemoved?.Invoke(cell);
            return true;
        }

        public bool HasItem(InventoryItem item) =>
            this.HasItems(item, 1);

        [Button]
        public bool HasItems(InventoryItem item, int count)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return count switch
            {
                < 0 => throw new ArgumentOutOfRangeException(nameof(count)),
                0 => true,
                _ => this.items.TryGetValue(item, out Cell cell) && cell.Count >= count
            };
        }

        [Button]
        public int GetCount(InventoryItem item)
        {
            return item == null
                ? 0
                : this.items.TryGetValue(item, out Cell cell)
                    ? cell.Count
                    : 0;
        }

        public IReadOnlyCollection<Cell> GetCells() => this.items.Values;

        [Serializable]
        public sealed class Cell
        {
            public event Action<int> OnCountChanged;

            public InventoryItem Item => _item;

            public int Count
            {
                get => _count;
                internal set
                {
                    _count = value;
                    this.OnCountChanged?.Invoke(_count);
                }
            }

            [SerializeField]
            private InventoryItem _item;

            [SerializeField]
            private int _count;

            public Cell(KeyValuePair<InventoryItem, int> item) : this(item.Key, item.Value)
            {
            }

            public Cell(Cell cell) : this(cell._item, cell._count)
            {
            }

            public Cell(InventoryItem item, int count)
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item));

                if (count < 0)
                    throw new ArgumentOutOfRangeException(nameof(count));

                _item = item;
                _count = count;
            }
        }
    }
}