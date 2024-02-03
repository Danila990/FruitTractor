using System;
using Enums;
using UnityEngine;

namespace Grid
{
    [CreateAssetMenu(fileName = "new GridSetting_", menuName = "Grid Setting", order = 0)]
    public class GridSetting : ScriptableObject
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