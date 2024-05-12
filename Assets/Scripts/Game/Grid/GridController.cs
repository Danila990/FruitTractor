using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Code
{
    public class GridController : MonoBehaviour, IInitializable
    {
        public event Action<Cell> OnCellEvent;

        [SerializeField] private List<LineCell> _lineCell = new List<LineCell>();

        public Vector2Int SizeGrid => new Vector2Int(_lineCell.Count, _lineCell[0].Cells.Count);

        public Cell _playerCell { get; private set; }
        public Dictionary<Vector2Int, Fruit> _fruits { get; private set; } = new Dictionary<Vector2Int, Fruit>();

        public void Initialize()
        {
            _playerCell = GetStartPlayerCell();
            _fruits = GetFruits();
        }

        public void CellEventInvoke(Cell cell)
        {
            OnCellEvent?.Invoke(cell);
        }

        private Cell GetStartPlayerCell()
        {
            foreach (var lineCell in _lineCell)
            {
                foreach (var cell in lineCell.Cells)
                {
                    if (cell._cellType.Equals(CellType.PlayerStart))
                    {
                        return cell;
                    }
                }
            }

            return null;
        }

        private Dictionary<Vector2Int, Fruit> GetFruits()
        {
            Dictionary<Vector2Int, Fruit> dictionary = new Dictionary<Vector2Int, Fruit>();
            foreach (var lineCell in _lineCell)
            {
                foreach (var cell in lineCell.Cells)
                {
                    if (cell._cellType.Equals(CellType.Fruit))
                    {
                        dictionary.Add(cell._gridIndex, cell.GetComponentInChildren<Fruit>());
                    }
                }
            }

            return dictionary;
        }

        public Cell GetCell(Vector2Int cellIndex)
        {
            return _lineCell[cellIndex.x].Cells[cellIndex.y];
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