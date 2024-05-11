using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    public class GridController : MonoBehaviour
    {
        public event Action<Cell> OnCellEvent;

        [SerializeField] private List<LineCell> _lineCell = new List<LineCell>();

        public Vector2Int SizeGrid => new Vector2Int(_lineCell.Count, _lineCell[0].Cells.Count);

        public void CellEventInvoke(Cell cell)
        {
            OnCellEvent?.Invoke(cell);
        }

        public Cell GetStartPlayerCell()
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

        public List<Cell> GetFruits()
        {
            return _lineCell
                    .SelectMany(lineCell => lineCell.Cells)
                    .Where(cell => cell._cellType == CellType.Fruit)
                    .ToList();
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