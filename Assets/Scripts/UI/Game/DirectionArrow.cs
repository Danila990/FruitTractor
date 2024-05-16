using System;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Code
{
    public class DirectionArrow : MonoBehaviour
    {
        [SerializeField] private DirectionArrowButton[] _directionButtonData;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnInputDirection += OnUpdateDirection;
        }
        
        public void OnCLickDirectionButton(DirectionArrowButton directionArrowButton)
        {
            _inputService.InvokeInputEvent(directionArrowButton._directionType);
        }

        private void OnUpdateDirection(DirectionType directionType)
        {
            ActivateAllButtons();
            foreach (var button in _directionButtonData)
            {
                if(button._directionType == directionType)
                {
                    button.ChangeInteractable(false);
                }
            }
        }

        private void ActivateAllButtons()
        {
            foreach (var button in _directionButtonData)
            {
                button.ChangeInteractable(true);
            }
        }
    }
}