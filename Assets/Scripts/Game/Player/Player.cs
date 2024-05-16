using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerRotation), typeof(PlayerGridNavigation))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _virtualCamera;

        private PlayerMovement _movement;
        private PlayerRotation _rotation;
        private PlayerGridNavigation _gridNavigation;
        private GridController _gridController;
        private GameManager _gameManager;
        private DirectionType _currentDirection;
        private IInputService _inputService;
        private Cell _currentCell;
        private bool _isStartGame = false;

        [Inject]
        private void Construct(GridController controller, IInputService inputService, GameManager gameManager)
        {
            _gameManager = gameManager;
            _gridController = controller;
            _inputService = inputService;
            _inputService.OnInputDirection += InputDirection;
            _gameManager.OnStartGame += OnStartGame;
        }

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _rotation = GetComponent<PlayerRotation>();
            _gridNavigation = GetComponent<PlayerGridNavigation>();
        }

        private void Start()
        {
            _rotation.RotateToDirection(_currentDirection, true);
            _currentCell = _gridController._playerCell;
            _movement.OnMoveComplete += MoveComplete;
        }

        private void OnStartGame()
        {
            _virtualCamera.gameObject.SetActive(true);
            _isStartGame = true;
        }

        private void MoveComplete()
        {
            if (_movement.IsMove || _isStartGame == false)
            {
                return;
            }

            if(_gridNavigation.TryGetNextCell(_currentDirection, _currentCell, out Cell returnCell))
            {
                _currentCell = returnCell;
                _movement.Move(returnCell);
                _rotation.RotateToDirection(_currentDirection);
            }
        }

        private void InputDirection(DirectionType typeDirection)
        {
            _currentDirection = typeDirection;
            MoveComplete();
        }

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= InputDirection;
            _movement.OnMoveComplete -= MoveComplete;
        }
    }
}