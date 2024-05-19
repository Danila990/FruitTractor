using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Code
{
    public class GridCreator : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private GridController _gridController;
        [SerializeField] private List<LineCell> _lineCell = new List<LineCell>();
        [SerializeField] private Transform _parrent;

        [Header("Ofssets")]
        [SerializeField] private float _cellsOffset = 3.2f;
        [SerializeField] private float _rockOffset = 0;
        [SerializeField] private float _fruitOfsset = 1;

        [Header("Prefabs")]
        [SerializeField] private Cell[] _cellPrefabs;
        [SerializeField] private GameObject[] _fruitPrefabs;
        [SerializeField] private GameObject[] _rocksPrefabs;
        [SerializeField] private GameObject _playerPrefab;

        public void ChangeCell(Cell previewCell, CellType cellType)
        {
            Cell newCell = Instantiate(_cellPrefabs.FirstOrDefault(cell => cell._cellType == cellType), _parrent);
            Vector2Int previewIndex = previewCell._gridIndex;
            _lineCell[previewIndex.x].Cells[previewIndex.y] = newCell;
            newCell.SetupIndex(previewIndex);
            newCell.transform.position = previewCell.transform.position;
            switch (cellType)
            {
                case CellType.Fruit:
                    GameObject fruit = Instantiate(_fruitPrefabs[Random.Range(0, _fruitPrefabs.Length)], newCell.transform);
                    Vector3 fruitPosition = newCell.transform.position;
                    fruitPosition.y += _fruitOfsset;
                    fruit.transform.position = fruitPosition;
                    break;

                case CellType.Rock:
                    GameObject rock = Instantiate(_rocksPrefabs[Random.Range(0, _rocksPrefabs.Length)], newCell.transform);
                    Vector3 rockPosition = newCell.transform.position;
                    rockPosition.y += _rockOffset;
                    rock.transform.position = rockPosition;
                    break;

                case CellType.PlayerStart:
                    GameObject player = Instantiate(_playerPrefab);
                    Vector3 playerPosition = newCell.transform.position;
                    playerPosition.y += _rockOffset;
                    player.transform.position = playerPosition;
                    break;
            }

            newCell.GetComponent<CellDebug>().SetupGridCreator(cellType);
            _gridController.Setup(_lineCell);
        }

        public void CreateGridCells()
        {
            RemoveGrid();

            Cell emptyCell = _cellPrefabs.FirstOrDefault(cell => cell._cellType == CellType.Empty);
            Vector3 middleOffset = CalculateMiddleOffset();
            for (int x = 0; x < _gridSize.x; x++)
            {
                LineCell lineCells = new LineCell();
                for (int y = 0; y < _gridSize.y; y++)
                {
                    Cell cell = Instantiate(emptyCell, _parrent.transform);
                    lineCells.Cells.Add(cell);
                    cell.transform.position = new Vector3(x * _cellsOffset, 0, y * _cellsOffset) - middleOffset + _parrent.transform.position;
                    cell.SetupIndex(new Vector2Int(x, y));
                }

                _lineCell.Add(lineCells);
            }

            _gridController.Setup(_lineCell);
        }
        
        private Vector3 CalculateMiddleOffset()
        {
            float gridWidth = _gridSize.x * _cellsOffset - _cellsOffset;
            float gridHeight = _gridSize.y * _cellsOffset - _cellsOffset;

            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }

        private void RemoveGrid()
        {
            foreach (var cell in _lineCell)
            {
                if(cell == null)
                {
                    break;
                }

                foreach (var line in cell.Cells)
                {
                    if (line == null)
                    {
                        break;
                    }

                    DestroyImmediate(line.gameObject);
                }
            }

            _gridController.RemoveGrid();
            _lineCell.Clear();
        }
#endif
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(GridCreator))]
    public class GridCreatorCustomEditor : Editor
    {
        private GridCreator _gridCreator;

        private void OnEnable()
        {
            _gridCreator = (GridCreator)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create Grid", GUILayout.Height(30)))
            {
                _gridCreator.CreateGridCells();
            }
        }
    }
#endif
}
