using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Inventories
{
    public sealed class InventoryGrid
    {
        //private readonly Inventory _inventory;
        private readonly Item[,] _grid;
        private readonly int _width;
        private readonly int _height;


        public InventoryGrid(int width, int height)
        {
            _width = width;
            _height = height;

            _grid = new Item[_width, _height];
        }


        public Vector2Int[] GetPositions(in Item item)
        {
            var positions = new List<Vector2Int>();
            for (var x = 0; x < _grid.GetLength(0); x++)
            for (var y = 0; y < _grid.GetLength(1); y++)
            {
                if (ReferenceEquals(_grid[x, y], item))
                {
                    positions.Add(new Vector2Int(x, y));
                }
            }

            return positions.ToArray();
        }

        public bool TryGetItem(Vector2Int position, out Item item)
        {
            item = null;

            if (!IsStartPositionValid(position)) return false;

            item = _grid[position.x, position.y];

            return item != null;
        }

        public bool FindFreePosition(Vector2Int size, out Vector2Int freePosition)
        {
            for (var y = 0; y < _grid.GetLength(1); y++)
            for (var x = 0; x < _grid.GetLength(0); x++)
            {
                if (!IsFree(x, y))
                    continue;

                freePosition = new Vector2Int(x, y);

                if (TryAddItem(size, freePosition))
                    return true;
            }

            freePosition = default;

            return false;
        }

        public bool TryAddItem(Vector2Int size, Vector2Int position)
        {
            if (!IsStartPositionValid(position)) return false;

            var end = position + size;

            if (IsStartPositionValid(end)) return false;

            for (var y = position.y; y <= end.y; y++)
            for (var x = position.x; x <= end.x; x++)
            {
                if (_grid[x, y] != null)
                    return false;
            }

            return true;
        }

        public void CopyTo(in Item[,] matrix)
        {
            Array.Copy(_grid, matrix, _grid.Length);
        }

        public void AddItem(Item item, Vector2Int position)
        {
            var start = position;
            var end = position + item.Size;

            for (var y = start.y; y < end.y; y++)
            for (var x = start.x; x < end.x; x++)
            {
                _grid[x, y] = item;
            }
        }

        public void RemoveItem(Item item, Vector2Int position)
        {
            var start = position;
            var end = position + item.Size;

            for (var y = start.y; y < end.y; y++)
            for (var x = start.x; x < end.x; x++)
            {
                _grid[x, y] = null;
            }
        }

        public void MoveItem(Item item, Vector2Int position)
        {
            throw new NotImplementedException();
        }

        public void ClearGrid()
        {
            for (var y = 0; y < _grid.GetLength(1); y++)
            {
                for (var x = 0; x < _grid.GetLength(0); x++)
                {
                    _grid[x, y] = null;
                }
            }
        }

        public bool IsFree(in int x, in int y) =>
            _grid[x, y] == null;

        public bool IsFree(in Vector2Int position) =>
            IsFree(position.x, position.y);


        public bool IsStartPositionValid(Vector2Int position) =>
            position.x >= 0 && position.x < _width &&
            position.y >= 0 && position.y < _height;
    }
}