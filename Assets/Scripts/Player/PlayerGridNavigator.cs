using Enums;
using GameGrid;
using GameGrid.Controllers;
using GameGrid.GridObject;
using UnityEngine;

namespace Player
{
    public class PlayerGridNavigator : MonoBehaviour
    {
        private LevelGridController _levelGridController;
        private Vector2Int _playerGridIndex, _startGridIndex;
        private int _gridLengthX, _gridLengthY;

        private void Awake()
        {
            _levelGridController = GameSceneContext.Instance._levelGridController;
            _playerGridIndex = _levelGridController.GetPlayerCell()._gridIndex;
            _startGridIndex = _playerGridIndex;
            _gridLengthX = _levelGridController.LengthX - 1;
            _gridLengthY = _levelGridController.LengthY - 1;
            
            GameSceneContext.Instance._gameManager.SubRestartEvent(Restart);
        }

        public bool TryGetNextCell(TypeDirection typeDirection, out GridCell nextCell)
        {
            nextCell = default;
            Vector2Int nextIndex;
            switch (typeDirection)
            {
                case TypeDirection.Up:
                    if (_gridLengthY > _playerGridIndex.y)
                    {
                        nextIndex = new Vector2Int(_playerGridIndex.x, _playerGridIndex.y + 1);
                        nextCell = _levelGridController.GetCell(nextIndex);
                        if (!nextCell._typeCell.Equals(TypeCell.Space))
                        {
                            _playerGridIndex = nextIndex;
                            return true;
                        }
                    }
                    return false;

                case TypeDirection.Down:
                    if (0 < _playerGridIndex.y)
                    {
                        nextIndex = new Vector2Int(_playerGridIndex.x, _playerGridIndex.y - 1);
                        nextCell = _levelGridController.GetCell(nextIndex);
                        if (!nextCell._typeCell.Equals(TypeCell.Space))
                        {
                            _playerGridIndex = nextIndex;
                            return true;
                        }
                    }
                    return false;

                case TypeDirection.Left:
                    if (0 < _playerGridIndex.x)
                    {
                        nextIndex = new Vector2Int(_playerGridIndex.x - 1, _playerGridIndex.y);
                        nextCell = _levelGridController.GetCell(nextIndex);

                        if (!nextCell._typeCell.Equals(TypeCell.Space))
                        {
                            _playerGridIndex = nextIndex;
                            return true;
                        }
                    }
                    return false;
                
                case TypeDirection.Right:
                    if (_gridLengthX > _playerGridIndex.x)
                    {
                        nextIndex = new Vector2Int(_playerGridIndex.x + 1, _playerGridIndex.y);
                        nextCell = _levelGridController.GetCell(nextIndex);

                        if (!nextCell._typeCell.Equals(TypeCell.Space))
                        {
                            _playerGridIndex = nextIndex;
                            return true;
                        }
                    }
                    return false;

                default: return false;
            }
        }

        private void Restart() => _playerGridIndex = _startGridIndex;
    }
}