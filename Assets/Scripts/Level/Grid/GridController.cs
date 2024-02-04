using Enums;
using UnityEngine;

namespace Level.Grid
{
    public class GridController : MonoBehaviour
    {
        public int LengthX => _cells.GetLength(0);
        public int LengthY => _cells.GetLength(1);
        
        private Cell[,] _cells;

        public void Initialization(Cell[,] cells)
        {
            _cells = cells;
        }
        
        public Cell GetCell(Vector2Int index) => GetCell(index.x, index.y);
        public Cell GetCell(int x, int y) => _cells[x,y];

        public Cell GetPlayerCell()
        {
            for (int x = 0; x < LengthX; x++)
                for (int z = 0; z < LengthY; z++)
                    if (_cells[x,z].Type == TypeCell.PlayerStart)
                        return _cells[x,z];
            
            Debug.LogError("No Player spawn point");
            return null;
        }
    }
}