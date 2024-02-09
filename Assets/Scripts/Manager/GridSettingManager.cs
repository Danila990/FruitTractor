using GameGrid;
using UnityEngine;

namespace Manager
{
    public class GridSettingManager : MonoBehaviour, IInit
    {
        private const string GRID_SETTING_PATH = "Data/GridSetting/GridSetting_";

        [SerializeField] private bool _isTestLoad = false;
        [SerializeField] private int _testLoadIndex = 1;
        
        public GridSetting _gridSetting { get; private set; }
        
        public void Init()
        {
            if (_isTestLoad)
                _gridSetting = Resources.Load<GridSetting>(GRID_SETTING_PATH + _testLoadIndex);
            else
                _gridSetting = Resources.Load<GridSetting>(GRID_SETTING_PATH + SceneLoadManager.Instance._currentLoadScene);
        }
    }
}