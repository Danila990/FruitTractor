using System;
using Enums;
using GameGrid.GridObject;
using Manager;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement),typeof(PlayerRotation), typeof(PlayerGridNavigator))]
    public class PlayerController : Singleton<PlayerController>
    {
        public event Action<GridCell> OnCurrentCell;

        [SerializeField] private GameObject _virtualCamera;
        
        private PlayerMovement _movement;
        private PlayerRotation _rotation;
        private PlayerGridNavigator _gridNavigator;
        private TypeDirection _currentDirection, _nextDirection, _startDirection;
        private GridCell _targetCell;
        private GameManager _gameManager;
        private bool _isMove = false;
        
        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _rotation = GetComponent<PlayerRotation>();
            _gridNavigator = GetComponent<PlayerGridNavigator>();
            
            _movement.Init();
            
            GameSceneContext gameSceneContext = GameSceneContext.Instance;
            _gameManager = gameSceneContext._gameManager;
            
            Restart();
            
            _startDirection = gameSceneContext._gridSettingManager._gridSetting.GridSettingData.PlayerDirection;
            gameSceneContext._inputManager._inputService.OnInputDirection += InputDirection;
            _gameManager.SubRestartEvent(Restart);
            _gameManager.SubPlayEvent(PlayGame);
        }
        
        public void MoveComplete()
        {
            if (_targetCell._typeCell == TypeCell.Rock)
            {
                _gameManager.LossEvent();
                return;
            }
            
            OnCurrentCell?.Invoke(_targetCell);
            _isMove = false;
            StartMove();
        }
        
        private void StartMove()
        {
            if (_isMove || !_gameManager._isPlayGame) return;

            if (_currentDirection.Equals(_nextDirection) &&
                _gridNavigator.TryGetNextCell(_currentDirection, out _targetCell))
                SetupNewMoveTarget();
            else
            {
                if (_gridNavigator.TryGetNextCell(_nextDirection, out _targetCell))
                {
                    _currentDirection = _nextDirection;
                    SetupNewMoveTarget();
                }
                else if (_gridNavigator.TryGetNextCell(_currentDirection, out _targetCell))
                    SetupNewMoveTarget();
            }
        }
        
        private void SetupNewMoveTarget()
        {
            _isMove = true;
            _rotation.RotateToDirection(_currentDirection);
            _movement.MoveToTarget(_targetCell.transform);
        }
        
        private void InputDirection(TypeDirection typeDirection)
        {
            if(!_gameManager._isPlayGame) return;
            
            _nextDirection = typeDirection;
            StartMove();
        }
        
        private void PlayGame() => _virtualCamera.SetActive(true);
        
        private void Restart()
        {
            _currentDirection = _startDirection;
            _nextDirection = _startDirection;
            _targetCell = null;
            _isMove = false;
            _virtualCamera.SetActive(false);
            _movement.Restart();
            _rotation.RotateToDirection(_startDirection, true);
        }
        
        private void OnDestroy() => GameSceneContext.Instance._inputManager._inputService.OnInputDirection += InputDirection;
    }
}