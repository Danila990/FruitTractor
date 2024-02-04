using Level.Grid.Setting;
using UnityEngine;

namespace Level.Grid.Generators
{
    public class CellGenerator
    {
        private const string CELL_PATH = "Prefabs/Cell";
        
        public Cell[,] Generate(GridSettingData gridSettingData, Transform spawnParent , float cellOffset)
        {
            Cell cellPrefab = Resources.Load<Cell>(CELL_PATH);
            
            Vector3 middleOffset = CalculateMiddleOffset(gridSettingData.GridSize, cellOffset);
            Cell[,] spawnCells = new Cell[gridSettingData.GridSize.x, gridSettingData.GridSize.y];
            
            for (int x = 0; x < gridSettingData.GridSize.x; x++)
            {
                for (int y = 0; y < gridSettingData.GridSize.y; y++)
                {
                    Vector3 cellPosition = new Vector3(x * cellOffset, 0, y * cellOffset) - middleOffset + spawnParent.position;
        
                    Cell cell = GameObject.Instantiate(cellPrefab, spawnParent);
                    cell.transform.position = cellPosition;
                    spawnCells[x,y] = cell;
                    //cell.InitCell(gridLine[x]._Line[y]._TypeCell,new Vector2Int(x, y));
                    
                    cell.name = $"Cell| X: {x} Y: {y}";
                }
            }
            return spawnCells;
        }
        
        private Vector3 CalculateMiddleOffset(Vector2Int gridSize, float cellOffset)
        {
            float gridWidth = gridSize.x * cellOffset - cellOffset;
            float gridHeight = gridSize.y * cellOffset - cellOffset;

            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }
    }
}