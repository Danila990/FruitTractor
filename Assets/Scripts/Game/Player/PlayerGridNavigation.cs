using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerGridNavigation : MonoBehaviour
    {
        private GridController _gridController;
        private Vector2Int _sizeGrid;

        [Inject]
        private void Construct(GridController controller)
        {
            _gridController = controller;
            _sizeGrid = _gridController.GetSizeGrid() - Vector2Int.one;
        }

        public bool TryGetNextCell(DirectionType currentDirection, Cell currentCell, out Cell returnCell)
        {
            Vector2Int currentIndex = currentCell._gridIndex;
            switch (currentDirection)
            {
                case DirectionType.Up:
                    currentIndex = new Vector2Int(currentIndex.x, currentIndex.y + 1);
                    break;
                case DirectionType.Down:
                    currentIndex = new Vector2Int(currentIndex.x, currentIndex.y - 1);
                    break;
                case DirectionType.Left:
                    currentIndex = new Vector2Int(currentIndex.x - 1, currentIndex.y);
                    break;
                case DirectionType.Right:
                    currentIndex = new Vector2Int(currentIndex.x + 1, currentIndex.y);
                    break;
            }

            currentIndex.Clamp(Vector2Int.zero, _sizeGrid);
            if(currentIndex == currentCell._gridIndex)
            {
                returnCell = default;
                return false;
            }

            returnCell = _gridController.GetCell(currentIndex);
            return true;
        }
    }
}