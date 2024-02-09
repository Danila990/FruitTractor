using System.Linq;
using Enums;
using GameGrid.GridObject;
using UnityEngine;

namespace GameGrid.Controllers
{
    public class LevelGridController : MonoBehaviour, IInitGameSceneContext
    {
        private GridCell[,] _cells;

        public int LengthX => _cells.GetLength(0);
        public int LengthY => _cells.GetLength(1);
        
        public void Init(GameSceneContext gameSceneContext)
        {
            _cells = gameSceneContext._levelGridCreator.CellGridSpawner.GetCells();
        }
        
        public GridCell GetCell(Vector2Int index) => GetCell(index.x, index.y);
        public GridCell GetCell(int x, int y) => _cells[x,y];

        public GridCell GetPlayerCell()
        {
            return (from GridCell item in _cells
                where item._typeCell == TypeCell.PlayerStart
                select item).FirstOrDefault();
        }
    }
}