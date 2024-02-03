using Grid;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace GameEditor
{
    public class GridHelper : MonoBehaviour
    {
        [Header("New grid setting")]
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private float _cellsOffset = 3.2f;
        [SerializeField] private Transform _spawnPostion;

        [Space, Header("Current Grid Setting")]
        [SerializeField] private GameObject _currentGrid;
        [SerializeField] private GridSetting _currentGridSetting;

        #region DublicateCurrentGrid
        public void DublicateCurrentGrid()
        {
            if (_currentGrid == null)
            {
                Debug.Log($"Error grid Setting: GameObject - {_currentGrid}, GridSetting - {_currentGridSetting}");
                return;
            }
            
            CreateNewGridSetting();
            SaveCurrentGridSetting();
        }
        #endregion
        
        #region LoadGridToCreate

        public void LoadGridToCreate()
        {
            if (_currentGridSetting == null)
            {
                Debug.Log($"Error grid Setting {_currentGridSetting}");
                return;
            }
            
            _gridSize = _currentGridSetting.GridSize;
            
            Vector3 middleOffset = CalculateMiddleOffset();
            
            _currentGrid = new GameObject();
            _currentGrid.name = "load Grid";
            _currentGrid.transform.position = _spawnPostion.position;
            
            for (int x = 0; x < _gridSize.x; x++)
            {
                GameObject line = new GameObject();
                line.transform.parent = _currentGrid.transform;
                line.name = $"Line {x}";
                
                for (int y = 0; y < _gridSize.y; y++)
                {
                    Cell cell = Instantiate(_cellPrefab, line.transform);
                    cell.transform.position = new Vector3(x * _cellsOffset, 0, y * _cellsOffset) - middleOffset + transform.position;
                    
                    cell.name = $"Cell {y}";
                    cell.Init( _currentGridSetting.LineData[x].CellData[y].Type);
                }
            }
        }
        #endregion
        
        #region SaveCurrentGridSetting
        public void SaveCurrentGridSetting()
        {
            if (_currentGridSetting == null || _currentGrid == null)
            {
                Debug.Log($"Error grid Setting: GameObject - {_currentGrid}, GridSetting - {_currentGridSetting}");
                return;
            }
            
            _currentGridSetting.GridSize = new Vector2Int(_currentGrid.transform.childCount, _currentGrid.transform.GetChild(0).childCount);
            _currentGridSetting.LineData = new LineData[_currentGridSetting.GridSize.x];

            for (int x = 0; x < _currentGridSetting.GridSize.x; x++)
            {
                _currentGridSetting.LineData[x].CellData = new CellData[_currentGridSetting.GridSize.y];

                for (int y = 0; y < _currentGridSetting.GridSize.y; y++)
                {
                    Cell cell = _currentGrid.transform.GetChild(x).GetChild(y).gameObject.GetComponent<Cell>();
                    _currentGridSetting.LineData[x].CellData[y].Type = cell.Type;
                }
            }
        }
        #endregion
        
        #region CreateNewGridSetting
        public void CreateNewGridSetting()
        {
            string dataPath = Application.dataPath + "/Resources/Data";
            string gridDataPath = dataPath + "/GridSetting";
            
            CreateDataSettingDirectory(dataPath, gridDataPath);
            CreateGridSetting(GetCountSettings(gridDataPath));
            SaveCurrentGridSetting();
        }

        private void CreateGridSetting(int number)
        {
            string pathSetting = $"Assets/Resources/Data/GridSetting/GridSetting_{number}.asset";
            
            GridSetting newGridSetting = ScriptableObject.CreateInstance<GridSetting>();
            _currentGridSetting = newGridSetting;
            AssetDatabase.CreateAsset(newGridSetting, pathSetting);
            AssetDatabase.SaveAssets();
            
            Debug.Log("Create new grid setting: " + newGridSetting.name);
        }
        
        private int GetCountSettings(string gridDataPath)
        {
            int i = 1;
            while (File.Exists( $"{gridDataPath}/GridSetting_{i}.asset"))
                i++;

            return i;
        }
        
        private void CreateDataSettingDirectory(string dataPath, string gridDataPath)
        {
            if (!Directory.Exists(dataPath)) 
            {
                Directory.CreateDirectory(dataPath);
                Debug.Log("Folder created at: " + dataPath);
                
                if (!Directory.Exists(gridDataPath))
                {
                    Directory.CreateDirectory(gridDataPath); 
                    Debug.Log("Folder created at: " + gridDataPath);
                }
            }
        }
        #endregion
        
        #region CreateCells
        public void CreateGridCells()
        {
            Vector3 middleOffset = CalculateMiddleOffset();
            
            _currentGrid = new GameObject();
            _currentGrid.name = "new Grid";
            _currentGrid.transform.position = _spawnPostion.position;
            
            for (int x = 0; x < _gridSize.x; x++)
            {
                GameObject line = new GameObject();
                line.transform.parent = _currentGrid.transform;
                line.name = $"Line {x}";
                
                for (int y = 0; y < _gridSize.y; y++)
                {
                    Cell cell = Instantiate(_cellPrefab, line.transform);
                    cell.transform.position = new Vector3(x * _cellsOffset, 0, y * _cellsOffset) - middleOffset + transform.position;
                    
                    cell.name = $"Cell {y}";
                }
            }
            CreateNewGridSetting();
        }
        
        private Vector3 CalculateMiddleOffset()
        {
            float gridWidth = _gridSize.x * _cellsOffset - _cellsOffset;
            float gridHeight = _gridSize.y * _cellsOffset - _cellsOffset;

            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }
        #endregion
    }
}
