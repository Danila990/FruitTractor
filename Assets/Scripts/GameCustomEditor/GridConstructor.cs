#if UNITY_EDITOR
using GameGrid;
using GameGrid.GridObject;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace GameCustomEditor
{
    public class GridConstructor : MonoBehaviour
    {
        [Header("New grid setting")]
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private GridCell _cellPrefab;
        [SerializeField] private float _cellsOffset = 3.2f;
        [SerializeField] private Transform _spawnPostion;

        [Space, Header("Current Grid Setting")]
        [SerializeField] private GameObject _gridGameObject;
        [SerializeField] private GridSetting _gridSetting;

        #region DublicateCurrentGrid
        public void DublicateCurrentGrid()
        {
            if (_gridGameObject == null)
            {
                Debug.Log($"Error grid Setting: GameObject - {_gridGameObject}, GridSetting - {_gridSetting}");
                return;
            }
            
            CreateNewGridSetting();
            SaveCurrentGridSetting();
        }
        #endregion
        
        #region LoadGridToCreate

        public void LoadGridToCreate()
        {
            if (_gridSetting == null)
            {
                Debug.Log($"Error grid Setting {_gridSetting}");
                return;
            }
            
            _gridSize = _gridSetting.GridSettingData.GridSize;
            
            Vector3 middleOffset = CalculateMiddleOffset();
            
            _gridGameObject = new GameObject();
            _gridGameObject.name = "load Grid";
            _gridGameObject.transform.position = _spawnPostion.position;
            
            for (int x = 0; x < _gridSize.x; x++)
            {
                GameObject line = new GameObject();
                line.transform.parent = _gridGameObject.transform;
                line.name = $"Line {x}";
                
                for (int y = 0; y < _gridSize.y; y++)
                {
                    GridCell cell = Instantiate(_cellPrefab, line.transform);
                    cell.transform.position = new Vector3(x * _cellsOffset, 0, y * _cellsOffset) - middleOffset + _gridGameObject.transform.position;
                    
                    cell.name = $"Cell {y}";
                    cell.Init(_gridSetting.GridSettingData.LineData[x].CellData[y].TypeCell, _gridSetting.GridSettingData.LineData[x].CellData[y].TypeFruit);
                }
            }
        }
        #endregion
        
        #region SaveCurrentGridSetting
        public void SaveCurrentGridSetting()
        {
            if (_gridSetting == null || _gridGameObject == null)
            {
                Debug.Log($"Error grid Setting: GameObject - {_gridGameObject}, GridSetting - {_gridSetting}");
                return;
            }
            
            _gridSetting.GridSettingData.GridSize = new Vector2Int(_gridGameObject.transform.childCount, _gridGameObject.transform.GetChild(0).childCount);
            _gridSetting.GridSettingData.LineData = new LineData[_gridSetting.GridSettingData.GridSize.x];

            for (int x = 0; x < _gridSetting.GridSettingData.GridSize.x; x++)
            {
                _gridSetting.GridSettingData.LineData[x].CellData = new CellData[_gridSetting.GridSettingData.GridSize.y];

                for (int y = 0; y < _gridSetting.GridSettingData.GridSize.y; y++)
                {
                    GridCell cell = _gridGameObject.transform.GetChild(x).GetChild(y).gameObject.GetComponent<GridCell>();
                    _gridSetting.GridSettingData.LineData[x].CellData[y].TypeCell = cell._typeCell;
                    _gridSetting.GridSettingData.LineData[x].CellData[y].TypeFruit = cell._typeFruit;
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
            _gridSetting = newGridSetting;
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
            
            _gridGameObject = new GameObject();
            _gridGameObject.name = "new Grid";
            _gridGameObject.transform.position = _spawnPostion.position;
            
            for (int x = 0; x < _gridSize.x; x++)
            {
                GameObject line = new GameObject();
                line.transform.parent = _gridGameObject.transform;
                line.name = $"Line {x}";
                
                for (int y = 0; y < _gridSize.y; y++)
                {
                    GridCell cell = Instantiate(_cellPrefab, line.transform);
                    cell.transform.position = new Vector3(x * _cellsOffset, 0, y * _cellsOffset) - middleOffset + _gridGameObject.transform.position;
                    
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

#endif


