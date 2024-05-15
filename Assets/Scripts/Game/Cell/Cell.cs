using UnityEngine;

namespace Code
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public CellType _cellType { get; private set; } = CellType.Empty;
        [field: SerializeField] public Vector2Int _gridIndex { get; private set; }

        public void SetupIndex(Vector2Int gridIndex)
        {
            _gridIndex = gridIndex;
        }

        public virtual void CellEvent()
        {
            
        }
    }
}