using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerRotation), typeof(PlayerGridNavigator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private DirectionType _startDirection;

        private PlayerMovement _movement;
        private PlayerRotation _rotation;
        private PlayerGridNavigator _gridNavigator;
        private DirectionType _currentDirection;
        private GridController _gridController;
        private IInputService _inputService;
        private Cell _currentCell;

        [Inject]
        private void Construct(GridController controller, IInputService inputService)
        {
            _gridController = controller;
            _inputService = inputService;
            _inputService.OnInputDirection += InputDirection;
            _gridController.OnCellEvent += MoveComplete;
        }

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _rotation = GetComponent<PlayerRotation>();
            _gridNavigator = GetComponent<PlayerGridNavigator>();
            _rotation.RotateToDirection(_currentDirection, true);
            _currentCell = _gridController._playerCell;
        }

        private void MoveComplete(Cell currentCell)
        {
            if (_movement.IsMove)
            {
                return;
            }

            if(_gridNavigator.TryGetNextCell(_currentDirection, currentCell, out Cell returnCell))
            {
                _currentCell = returnCell;
                _movement.Move(returnCell);
                _rotation.RotateToDirection(_currentDirection);
            }
        }

        private void InputDirection(DirectionType typeDirection)
        {
            _currentDirection = typeDirection;
            MoveComplete(_currentCell);
        }

        private void OnDestroy()
        {
            _gridController.OnCellEvent -= MoveComplete;
            _inputService.OnInputDirection -= InputDirection;
        }
    }
}