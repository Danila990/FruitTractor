using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
    public class GridController : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<LineCell> _lineCell = new List<LineCell>();

        public Cell _playerCell { get; private set; }
        public List<FruitCell> _fruits { get; private set; } = new List<FruitCell>();

        public void Initialize()
        {
            FindNeedCells();
        }

        public Vector2Int GetSizeGrid()
        {
            return new Vector2Int(_lineCell.Count, _lineCell[0].Cells.Count);
        }

        public Cell GetCell(Vector2Int cellIndex)
        {
            return _lineCell[cellIndex.x].Cells[cellIndex.y];
        }

        private void FindNeedCells()
        {
            foreach (var lineCell in _lineCell)
            {
                foreach (var cell in lineCell.Cells)
                {
                    if (cell._cellType.Equals(CellType.PlayerStart))
                    {
                        _playerCell = cell;
                    }
                    else if (cell._cellType.Equals(CellType.Fruit))
                    {
                        _fruits.Add(cell as FruitCell);
                    }
                }
            }
        }
#if UNITY_EDITOR
        public void Setup(List<LineCell> lineCell)
        {
            _lineCell = lineCell;
        }

        public void RemoveGrid()
        {
            _lineCell.Clear();
        }

        public List<LineCell> GetGridLine()
        {
            return _lineCell;
        }
#endif
    }

    [Serializable]
    public class LineCell
    {
        public List<Cell> Cells = new List<Cell>();
    }
}