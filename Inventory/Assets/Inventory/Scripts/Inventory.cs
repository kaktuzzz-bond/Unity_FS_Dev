using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private readonly Dictionary<Item, Vector2Int[]> _items = new();

        //private readonly InventoryGrid _oldGrid;
        private readonly InventoryController _controller;
        
        private readonly bool[,] _grid;

        public Inventory(in int width, in int height)
        {
            if (width < 0 || height < 0 || (width == 0 && height == 0))
                throw new ArgumentException("Invalid size exception");

            Width = width;
            Height = height;
            
            _grid = new bool[width, height];
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

            foreach (var item in items)
            {
                AddItem(item);
            }
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

            foreach (var item in items)
            {
                AddItem(item);
            }
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
            if (!ItemIsNotNullAndHasValidSize(item)) return false;

            var position = new Vector2Int(posX, posY);

            if (!_oldGrid.TryAddItem(item.Size, position)) return false;

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

            _items.Add(item, position);
            
            AddItemToGrid(item, position);

            OnAdded?.Invoke(item, position);

            return true;
        }
        private void AddItemToGrid(Item item, Vector2Int position)
        {
            var start = position;
            var end = position + item.Size;

            for (var y = start.y; y < end.y; y++)
            for (var x = start.x; x < end.x; x++)
            {
                _oldGrid[x, y] = item;
            }
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
            if (!CanAddItem(item)) return false;

            return FindFreePosition(item, out var freePosition) &&
                   AddItem(item, freePosition);
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
        {
            if (!ItemIsNotNullAndHasValidSize(item)) return false;

            return FindFreePosition(item, out var freePosition) &&
                   CanAddItem(item, freePosition);
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Item item, out Vector2Int freePosition)
        {
            return FindFreePosition(item.Size, out freePosition);
        }

        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            freePosition = default;
            if( !IsSizeValid(size)) return false;
               
            for (var y = 0; y < _oldGrid.GetLength(1); y++)
            for (var x = 0; x < _oldGrid.GetLength(0); x++)
            {
                if (!IsFree(x, y))
                    continue;

                freePosition = new Vector2Int(x, y);

                if (TryAddItemToGrid(size, freePosition))
                    return true;
            }

            freePosition = default;

            return false;
        }

        private bool TryAddItemToGrid(Vector2Int size, Vector2Int position)
        {
            if (!IsStartPositionValid(position)) return false;

            var end = position + size;

            if (IsStartPositionValid(end)) return false;

            for (var y = position.y; y <= end.y; y++)
            for (var x = position.x; x <= end.x; x++)
            {
                if (_oldGrid[x, y] != null)
                    return false;
            }

            return true;
        }
        public bool FindFreePosition(in int sizeX, int sizeY, out Vector2Int freePosition)
        {
            var size = new Vector2Int(sizeX, sizeY);
            return FindFreePosition(size, out freePosition);
        }

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            return ItemIsNotNullAndHasValidSize(item) &&
                   _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position) =>
            !IsFree(position);

        public bool IsOccupied(in int x, in int y) =>
            !IsFree(x, y);

        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position) =>
            IsFree(position.x, position.y);

        public bool IsFree(in int x, in int y) =>
            _oldGrid[x, y] == null;

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item)
        {
            return RemoveItem(item, out _);
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            position = default;

            if (!ItemIsNotNullAndHasValidSize(item)) return false;

            if (!_items.Remove(item, out position)) return false;

            RemoveItemFromGrid(item, out position);
                
            OnRemoved?.Invoke(item, position);

            return true;
        }

        public void RemoveItemFromGrid(Item item, Vector2Int position)
        {
            var start = position;
            var end = position + item.Size;

            for (var y = start.y; y < end.y; y++)
            for (var x = start.x; x < end.x; x++)
            {
                _oldGrid[x, y] = null;
            }
        }
        
        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            return TryGetItem(position, out var item) ? item : null;
        }

        public Item GetItem(in int x, in int y)
        {
            var position = new Vector2Int(x, y);

            if (!_oldGrid.IsStartPositionValid(position))
                throw new IndexOutOfRangeException("Invalid position.");

            var item = GetItem(position);

            if (item == null)
                throw new NullReferenceException("Item is null.");

            return item;
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            item = null;

            if (!IsStartPositionValid(position)) return false;

            item = _oldGrid[position.x, position.y];

            return item != null;
        }

        public bool TryGetItem(in int x, in int y, out Item item)
        {
            var position = new Vector2Int(x, y);
            return TryGetItem(position, out item);
        }

        /// <summary>
        /// Returns matrix positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(in Item item)
        {
            if (item == null)
                throw new NullReferenceException("Item is null.");

            if (!Contains(item))
                throw new KeyNotFoundException("Item not found.");


            return TryGetPositions(item, out var positions)
                ? positions
                : Array.Empty<Vector2Int>();
        }

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
        {
            positions = default;
            
            if (!ItemIsNotNullAndHasValidSize(item)) return false;
            
            if (!_items.TryGetValue(item, out var position)) return false;
            

            var end = position + item.Size;
            
            for (var y = position.y; y < end.y; y++)
            for (var x = position.x; x < end.x; x++)
            {
                if (_oldGrid[x, y] != null)
                    return false;
            }
            
            return true;
        }

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            if (Count <= 0) return;

            ClearGrid();

            OnCleared?.Invoke();
        }

        private void ClearGrid()
        {
            _items.Clear();

            for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
            {
                _oldGrid[x, y] = null;
            }
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name) =>
            this.Count(x => x.Name == name);

        /// <summary>
        /// Moves a specified item at target position if exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int position) =>
            throw new NotImplementedException();

        /// <summary>
        /// Reorganizes an inventory space so that the free area is uniform
        /// </summary>
        public void ReorganizeSpace() =>
            throw new NotImplementedException();

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix) =>
            Array.Copy(_oldGrid, matrix, _oldGrid.Length);


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

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        private bool ItemIsNotNullAndHasValidSize(in Item item)
        {
            return IsNotNull(item) && IsSizeValid(item.Size);
        }

        private bool IsNull(Item item) =>
            item == null;

        private bool IsNotNull(Item item) =>
            item != null;

        private bool IsSizeValid(Vector2Int size)
        {
            if (size.x <= 0 || size.y <= 0)
                throw new ArgumentException("Invalid size exception");

            return true;
        }
        
        private bool IsStartPositionValid(Vector2Int position) =>
            position.x >= 0 && position.x < Width &&
            position.y >= 0 && position.y < Height;
        
        private Vector2Int[] GetPositionsFromGrid(in Item item)
        {
            var positions = new List<Vector2Int>();
            for (var x = 0; x < _oldGrid.GetLength(0); x++)
            for (var y = 0; y < _oldGrid.GetLength(1); y++)
            {
                if (ReferenceEquals(_oldGrid[x, y], item))
                {
                    positions.Add(new Vector2Int(x, y));
                }
            }

            return positions.ToArray();
        }
    }
}