using UnityEngine;

namespace Grid
{
    public class CellGenerator : MonoBehaviour
    {
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private float _cellOffset = 3.2f;
        
        [ContextMenu("Create Cells")]
        public void CreateCells()
        {
            Vector3 middleOffset = CalculateMiddleOffset();
            
            for (int x = 0; x < _gridSize.x; x++)
            {
                GameObject line = new GameObject();
                line.transform.parent = transform;
                line.name = $"Line {x}";
                
                for (int y = 0; y < _gridSize.y; y++)
                {
                    Cell cell = Instantiate(_cellPrefab, line.transform);
                    cell.transform.position = new Vector3(x * _cellOffset, 0, y * _cellOffset) - middleOffset + transform.position;
                    
                    cell.name = $"Cell {y}";
                }
            }
        }

        private Vector3 CalculateMiddleOffset()
        {
            float gridWidth = _gridSize.x * _cellOffset - _cellOffset;
            float gridHeight = _gridSize.y * _cellOffset - _cellOffset;

            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }
    }
}
