using System;
using Enums;
using UnityEngine;

namespace GameGrid
{
    [CreateAssetMenu(fileName = "new GridSetting", menuName = "Grid/GridSetting", order = 0)]
    public class GridSetting : ScriptableObject
    {
        public GridSettingData GridSettingData;
    }
    
    [Serializable]
    public struct GridSettingData
    {
        public Vector2Int GridSize;
        public LineData[] LineData;
        public TypeDirection PlayerDirection;
        public int Timer;
    }
    
    [Serializable]
    public struct LineData
    {
        public CellData[] CellData;
    }
    
    [Serializable]
    public struct CellData
    {
        public TypeCell TypeCell;
        public TypeFruit TypeFruit;
    }
}