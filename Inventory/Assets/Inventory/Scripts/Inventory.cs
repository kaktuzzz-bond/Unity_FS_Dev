using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public int Count => _items.Count(pair => pair.Value != null);

        private readonly Dictionary<Vector2Int, Item> _items = new();

        // private void Counter()
        // {
        //     int counter = _items.Count(pair => pair.Value == null);
        // }
        public Inventory(in int width, in int height)
        {
            if (width < 0 || height < 0 || (width == 0 && height == 0))
                throw new ArgumentException("Invalid size exception");

            Width = width;
            Height = height;

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var key = new Vector2Int(x, y);
                    _items.Add(key, null);
                }
            }
        }

        public Inventory(
            in int width,
            in int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
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
        public bool CanAddItem(in Item item, in Vector2Int position) =>
            throw new NotImplementedException();

        public bool CanAddItem(in Item item, in int posX, in int posY) =>
            throw new NotImplementedException();

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position) =>
            throw new NotImplementedException();

        public bool AddItem(in Item item, in int posX, in int posY) =>
            throw new NotImplementedException();

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item) =>
            throw new NotImplementedException();

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item) =>
            throw new NotImplementedException();

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Item item, out Vector2Int freePosition) =>
            throw new NotImplementedException();

        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition) =>
            throw new NotImplementedException();

        public bool FindFreePosition(in int sizeX, int sizeY, out Vector2Int freePosition) =>
            throw new NotImplementedException();

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item) =>
            throw new NotImplementedException();

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position) =>
            throw new NotImplementedException();

        public bool IsOccupied(in int x, in int y) =>
            throw new NotImplementedException();

        /// <summary>
        /// Checks if the a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position)
        {
            _items.TryGetValue(position, out var item);
            return item == null;
        }

        public bool IsFree(in int x, in int y)
        {
            var key = new Vector2Int(x, y);
            return IsFree(key);
        }

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item) =>
            throw new NotImplementedException();

        public bool RemoveItem(in Item item, out Vector2Int position) =>
            throw new NotImplementedException();

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
        public void Clear() =>
            throw new NotImplementedException();

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

        public IEnumerator<Item> GetEnumerator() =>
            throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator() =>
            throw new NotImplementedException();
    }
}