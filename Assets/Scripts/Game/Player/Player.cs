﻿using System;
using UnityEngine;
using Zenject;

namespace Code
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerRotation), typeof(PlayerGridNavigator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _virtualCamera;
        [SerializeField] private DirectionType _startDirection;

        private PlayerMovement _movement;
        private PlayerRotation _rotation;
        private PlayerGridNavigator _gridNavigator;
        private DirectionType _currentDirection;
        private GridController _gridController;
        private IInputService _inputService;

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
        }

        private void MoveComplete(Cell currentCell)
        {
            if(_gridNavigator.TryGetNextCell(_currentDirection, currentCell, out Cell returnCell))
            {
                _movement.Move(returnCell);
                _rotation.RotateToDirection(_currentDirection);
            }
        }

        private void InputDirection(DirectionType typeDirection)
        {
            _currentDirection = typeDirection;
        }

        private void StartGame() 
        {
            _virtualCamera.SetActive(true);
        }
        
        private void OnDestroy()
        {
            _inputService.OnInputDirection -= InputDirection;
        }
    }
}