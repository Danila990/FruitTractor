using Level.Grid.Setting;
using UnityEngine;

namespace Level.Grid.Generators
{
    public class GridGenerator : MonoBehaviour
    {
        private const string GRID_SETTING_PATH = "Data/GridSetting/GridSetting_";
        
        [Header("Setting")]
        [SerializeField] private bool _isTest = false;
        [SerializeField] private int _loadSettingIndex;
        [Header("Grid")]
        [SerializeField] private Transform _spawnParent;
        [SerializeField] private float _cellOffset = 3.2f;
        
        public void Initialization(GridController gridController)
        {
            GridSettingData gridSettingData = LoadGridSetting().GridSettingData;

            Cell[,] cells = new CellGenerator().Generate(gridSettingData, _spawnParent, _cellOffset);
        }
        
        private GridSetting LoadGridSetting()
        {
            if (_isTest)
                return Resources.Load<GridSetting>(GRID_SETTING_PATH + _loadSettingIndex);
            else
                return Resources.Load<GridSetting>(GRID_SETTING_PATH + _loadSettingIndex);
        }
    }
}