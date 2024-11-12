using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Codice.Client.BaseCommands.Differences;
using UnityEditor;
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

        private readonly Item[,] _grid;

        public Inventory(in int width, in int height)
        {
            if (width < 0 || height < 0 || (width == 0 && height == 0))
                throw new ArgumentException("Invalid size exception");

            Width = width;
            Height = height;

            _grid = new Item[Width, Height];
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
            //item
            if (IsNull(item)) return false;
            if (Contains(item)) return false;
            if (!IsSizeValid(item.Size)) return false;

            //position
            if (!IsPositionValid(position)) return false;
            if (!TryAddItem(position, item.Size)) return false;

            return true;
        }

        private bool TryAddItem(Vector2Int start, Vector2Int size)
        {
            if (!IsPositionValid(start)) return false;
            if (!IsSizeValid(size)) return false;

            var end = start + size;

            if (!IsPositionValid(end - Vector2Int.one)) return false;

            for (var x = start.x; x < end.x; x++)
            for (var y = start.y; y < end.y; y++)
            {
                if (_grid[x, y] != null)
                    return false;
            }

            return true;
        }

        public bool CanAddItem(in Item item, in int posX, in int posY)
        {
            var position = new Vector2Int(posX, posY);

            return CanAddItem(item, position);
        }


        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (!CanAddItem(item, position)) return false;

            if (!PlaceOnGrid(item, position, out var positions)) return false;

            _items.Add(item, positions);

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
            freePosition = default;

            if (!ItemIsNotNullAndHasValidSize(item)) return false;

            return FindFreePosition(item.Size, out freePosition);
        }

        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            freePosition = default;

            if (!IsSizeValid(size)) return false;

            for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
            {
                if (IsOccupied(x, y)) continue;

                freePosition = new Vector2Int(x, y);

                if (TryAddItem(freePosition, size)) return true;
            }

            //is not necessary
            freePosition = default;

            return false;
        }

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            if (IsNull(item)) return false;
            return _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position) =>
            IsOccupied(position.x, position.y);

        public bool IsOccupied(in int x, in int y) =>
            _grid[x, y] != null;

        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position) =>
            IsFree(position.x, position.y);

        public bool IsFree(in int x, in int y) =>
            _grid[x, y] == null;

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

            if (!Contains(item)) return false;

            var positions = _items[item];

            position = positions[0];

            ClearGridOnPositions(positions);

            _items.Remove(item);

            OnRemoved?.Invoke(item, position);

            return true;
        }

        private void ClearGridOnPositions(Vector2Int[] positions)
        {
            foreach (var pos in positions)
            {
                _grid[pos.x, pos.y] = null;
            }
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            if (!IsPositionValid(position))
                throw new IndexOutOfRangeException("Invalid position.");

            _ = TryGetItem(position, out var item);

            if (IsNull(item))
                throw new NullReferenceException("Item is null.");

            return item;
        }

        public Item GetItem(in int x, in int y)
        {
            var position = new Vector2Int(x, y);
            return GetItem(position);
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            item = null;

            if (!IsPositionValid(position)) return false;

            if (IsOccupied(position))
            {
                item = _grid[position.x, position.y];
            }

            return IsNotNull(item);
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

            if (!_items.TryGetValue(item, out positions)) return false;

            return true;
        }

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            if (Count <= 0) return;

            _items.Clear();

            Array.Clear(_grid, 0, _grid.Length);

            OnCleared?.Invoke();
        }


        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name) =>
            this.Count(x => x.Name == name);

        /// <summary>
        /// Moves a specified item at target position if exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int position)
        {
            if (IsNull(item))
                throw new ArgumentNullException($":: {nameof(MoveItem)} :: NULL in {position}");

            //если поставить проверку на пустое имя без проверки Contains - тест пройдет
            //if (item.Name == string.Empty)return false;

            if (!Contains(item)) return false;

            if (!IsSizeValid(item.Size)) return false;

            if (!IsPositionValid(position)) return false;

            // var positions = _items[item];
            // ClearGridOnPositions(positions);

           // if(!PlaceOnGrid(item, position, out var positions)) return false;
            
            if (!TryAddItem(position, item.Size)) return false;

            OnMoved?.Invoke(item, position);

            return true;
        }

        /// <summary>
        /// Reorganizes an inventory space so that the free area is uniform
        /// </summary>
        public void ReorganizeSpace()
        {
            var copy = new Item[Width, Height];

            CopyTo(copy);

            var items = new List<Item>(_items
                .OrderByDescending(x => x.Value.Length)
                .Select(pair => pair.Key));

            Clear();

            foreach (var item in items)
            {
               AddItem(item);
            }
        }

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix) =>
            Array.Copy(_grid, matrix, _grid.Length);


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

        private bool ItemIsNotNullAndHasValidSize(in Item item) =>
            IsNotNull(item) && IsSizeValid(item.Size);

        private bool IsNull(Item item) =>
            item == null;

        private bool IsNotNull(Item item) =>
            item != null;


        private bool PlaceOnGrid(Item item, Vector2Int start, out Vector2Int[] positions)
        {
            positions = default;

            var end = start + item.Size;

            if (!IsPositionValid(end - Vector2Int.one)) return false;

            positions = new Vector2Int[item.Size.x * item.Size.y];

            var counter = 0;

            //если поменять местами строку итерации X и Y - тест красный
            //хотя логика не меняется
            for (var x = start.x; x < end.x; x++)
            for (var y = start.y; y < end.y; y++)
            {
                var position = new Vector2Int(x, y);
                positions[counter] = position;
                _grid[x, y] = item;
                counter++;
            }

            OnAdded?.Invoke(item, positions[0]);

            return true;
        }

        private bool IsSizeValid(Vector2Int size)
        {
            if (size.x <= 0 || size.y <= 0)
                throw new ArgumentException("Invalid size exception");

            if (size.x > Width || size.y > Height) return false;

            return true;
        }

        private bool IsPositionValid(Vector2Int position) =>
            position.x >= 0 && position.x < Width &&
            position.y >= 0 && position.y < Height;
    }
}