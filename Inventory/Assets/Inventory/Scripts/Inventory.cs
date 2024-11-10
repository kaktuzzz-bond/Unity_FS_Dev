using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codice.CM.Common.Purge;
using UnityEngine;

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width { get; }

        public int Height { get; }

        public int Count => _items.Count;

        private readonly Dictionary<Item, Vector2Int> _items = new();
        private readonly InventoryGrid _grid;

        public Inventory(in int width, in int height)
        {
            if (width < 0 || height < 0 || (width == 0 && height == 0))
                throw new ArgumentException("Invalid size exception");

            Width = width;
            Height = height;
            _grid = new InventoryGrid(this);
        }

        public Inventory(
            in int width,
            in int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));

            foreach (var pair in items)
            {
                AddItem(pair.Key, pair.Value);
            }
        }

        public Inventory(
            in int width,
            in int height,
            params Item[] items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
            foreach (var pair in items)
            {
                AddItem(pair.Key, pair.Value);
            }
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<Item> items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
        }


        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in Vector2Int position)
        {
            return CanAddItem(item, position.x, position.y);
        }

        public bool CanAddItem(in Item item, in int posX, in int posY)
        {
            if (IsNull(item)) return false;

            if (!_grid.TryAddItem(item, posX, posY)) return false;

            if (Contains(item)) return false;

            return true;
        }


        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (!CanAddItem(item, position)) return false;

            if (!_items.TryAdd(item, position)) return false;

            OnAdded?.Invoke(item, position);

            return true;
        }

        public bool AddItem(in Item item, in int posX, in int posY)
        {
            var position = new Vector2Int(posX, posY);

            return AddItem(item, position);
        }

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
        {
            // 1 - Ask if we can add the item
            // 2 - add the item if possible
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
        {
            if (IsNull(item)) return false;

            // 1 - find free position
            // 2 - return true if possible
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Item item, out Vector2Int freePosition) =>
            throw new NotImplementedException();

        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            
            throw new NotImplementedException();
        }

        public bool FindFreePosition(in int sizeX, int sizeY, out Vector2Int freePosition) =>
            throw new NotImplementedException();

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            if (IsNull(item))
                throw new ArgumentNullException(nameof(item));

            return _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position) =>
            !IsFree(position);

        public bool IsOccupied(in int x, in int y) =>
            !IsFree(x, y);

        /// <summary>
        /// Checks if the a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position) =>
            _grid[position] == null;

        public bool IsFree(in int x, in int y) =>
            _grid[x, y] == null;

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item)
        {
            if (IsNull(item)) return false;
            if (!_items.TryGetValue(item, out var pos)) return false;

            OnRemoved?.Invoke(item, pos);

            return _items.Remove(item);
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            position = default;
            return RemoveItem(item);
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position) =>
            throw new NotImplementedException();

        public Item GetItem(in int x, in int y) =>
            throw new NotImplementedException();

        public bool TryGetItem(in Vector2Int position, out Item item) =>
            throw new NotImplementedException();

        public bool TryGetItem(in int x, in int y, out Item item) =>
            throw new NotImplementedException();

        /// <summary>
        /// Returns matrix positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(in Item item) =>
            throw new NotImplementedException();

        public bool TryGetPositions(in Item item, out Vector2Int[] positions) =>
            throw new NotImplementedException();

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            OnCleared?.Invoke();
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name) =>
            throw new NotImplementedException();

        /// <summary>
        /// Moves a specified item at target position if exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int position) =>
            throw new NotImplementedException();

        /// <summary>
        /// Reorganizes a inventory space so that the free area is uniform
        /// </summary>
        public void ReorganizeSpace() =>
            throw new NotImplementedException();

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix) =>
            throw new NotImplementedException();


        public IEnumerator<Item> GetEnumerator()
        {
            var enumerator = _items.GetEnumerator();

            var items = new List<Item>();

            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current.Key);
            }

            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsNull(Item item) =>
            item == null;
    }
}