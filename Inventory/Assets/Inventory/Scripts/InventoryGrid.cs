using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Inventories
{
    public sealed class InventoryGrid
    {
        private readonly Inventory _inventory;
        private readonly Item[,] _grid;


        public InventoryGrid(Inventory inventory)
        {
            _inventory = inventory;
            _grid = new Item[inventory.Width, inventory.Height];

            _inventory.OnAdded += AddItem;
            _inventory.OnRemoved += RemoveItem;
            _inventory.OnMoved += MoveItem;
            _inventory.OnCleared += ClearGrid;
        }

        public Item this[int x, int y]
        {
            get => _grid[x, y];
            private set => _grid[x, y] = value;
        }

        public Item this[Vector2Int pos] =>
            _grid[pos.x, pos.y];


        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool TryAddItem(Item item, Vector2Int position)
        {
            if (!IsStartPositionValid(position)) return false;

            var end = position + item.Size;

            if (IsIndexOutOfRange(end)) return false;

            for (var y = position.y; y < end.y; y++)
            for (var x = position.x; x < end.x; x++)
            {
                if (_grid[x, y] != null)
                    return false;
            }

            return true;
        }


        public bool TryAddItem(Item item, int posX, int posY)
        {
            var pos = new Vector2Int(posX, posY);

            return TryAddItem(item, pos);
        }


        private void AddItem(Item item, Vector2Int position)
        {
            var start = position;
            var end = position + item.Size;

            for (var y = start.y; y < end.y; y++)
            for (var x = start.x; x < end.x; x++)
            {
                _grid[x, y] = item;

                //Debug.Log($"Add item {item} at {new Vector2Int(x, y)}");
            }
        }

        private void RemoveItem(Item item, Vector2Int position)
        {
            var start = position;
            var end = position + item.Size;

            for (var y = start.y; y < end.y; y++)
            for (var x = start.x; x < end.x; x++)
            {
                _grid[x, y] = null;
            }
        }

        private void MoveItem(Item item, Vector2Int position)
        {
            throw new NotImplementedException();
        }

        private void ClearGrid()
        {
            for (var y = 0; y < _grid.GetLength(1); y++)
            {
                for (var x = 0; x < _grid.GetLength(0); x++)
                {
                    _grid[x, y] = null;
                }
            }
        }

        public void Dispose()
        {
            _inventory.OnAdded -= AddItem;
            _inventory.OnRemoved -= RemoveItem;
            _inventory.OnMoved -= MoveItem;
            _inventory.OnCleared -= ClearGrid;
        }

        private bool IsStartPositionValid(Vector2Int position) =>
            position.x >= 0 && position.x < _inventory.Width &&
            position.y >= 0 && position.y < _inventory.Height;

        private bool IsIndexOutOfRange(Vector2Int position) =>
            position.x > _inventory.Width ||
            position.y > _inventory.Height;
        
    }
}