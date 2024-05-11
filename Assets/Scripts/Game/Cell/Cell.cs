using System.Collections;
using UnityEngine;
using Zenject;

namespace Code
{
    [RequireComponent(typeof(CellColor))]
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public CellType _cellType { get; private set; } = CellType.Empty;

        public Vector2Int _gridIndex { get; private set; }

        private GridController _controller;

        [Inject]
        private void Construct(GridController controller)
        {
            _controller = controller;
        }

        public void SetupIndex(Vector2Int gridIndex)
        {
            _gridIndex = gridIndex;
        }

        public void CellEvent()
        {
            _controller.CellEventInvoke(this);
        }
    }
}