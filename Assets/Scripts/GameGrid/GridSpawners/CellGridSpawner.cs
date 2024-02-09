using GameGrid.GridObject;
using UnityEngine;

namespace GameGrid.GridSpawners
{
    public class CellGridSpawner : MonoBehaviour
    {
        private const string CELL_PATH = "Prefabs/GridCell";
        
        [SerializeField] private  Transform _cellParent;
        [SerializeField] private  float _cellOffset;
        [SerializeField] private GridCell[,] _spawnCells;
        
        private GridCell _cellPrefab;
        public void Spawn(GridSettingData gridSettingData)
        {
            LoadPrefab();
            
            _spawnCells = new GridCell[gridSettingData.GridSize.x, gridSettingData.GridSize.y];
            
            Vector3 middleOffset = CalculateMiddleOffset(gridSettingData.GridSize, _cellOffset);
            Vector2Int gridSize = gridSettingData.GridSize;
            
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    Vector3 spawnPosition = new Vector3(x * _cellOffset, 0, y * _cellOffset) - middleOffset + _cellParent.position;
        
                    GridCell cell = Instantiate(_cellPrefab, _cellParent);
                    
                    cell.transform.position = spawnPosition;
                    _spawnCells[x,y] = cell;
                    cell.Init(gridSettingData.LineData[x].CellData[y].TypeCell ,new Vector2Int(x, y));
                    cell.name = $"Cell| X: {x} Y: {y}";
                }
            }
        }

        public GridCell[,] GetCells() => _spawnCells;

        private void LoadPrefab() => _cellPrefab = Resources.Load<GridCell>(CELL_PATH);
        
        private Vector3 CalculateMiddleOffset(Vector2Int gridSize, float cellOffset)
        {
            float gridWidth = gridSize.x * cellOffset - cellOffset;
            float gridHeight = gridSize.y * cellOffset - cellOffset;

            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }
    }
}