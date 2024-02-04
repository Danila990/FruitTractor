using System;
using Enums;
using UnityEngine;

namespace Level.Grid.Setting
{
    [CreateAssetMenu(fileName = "new GridSetting", menuName = "Grid Setting", order = 0)]
    public class GridSetting : ScriptableObject
    {
        public GridSettingData GridSettingData;
    }
    
    [Serializable]
    public struct GridSettingData
    {
        public Vector2Int GridSize;
        public LineData[] LineData;
    }
    
    [Serializable]
    public struct LineData
    {
        public CellData[] CellData;
    }
    
    [Serializable]
    public struct CellData
    {
        public TypeCell Type;
    }
}