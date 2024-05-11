using System;
using Enums;
using UnityEngine;

namespace Code
{
    public class MobileInputService : MonoBehaviour, IInputService
    {
        public event Action<DirectionType> OnInputDirection;
        
        private int _minDragingRange = 125;
        private int _maxDragingRange = 1000;
        private Vector2 _startTouch;

        private void Update() => Inputs();

        private void Inputs()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 swipeDelta = (Vector2)Input.mousePosition - _startTouch;

                CalculateDirection(swipeDelta);

                _startTouch = Vector2.zero;
            }
        }

        private void CalculateDirection(Vector2 swipeDelta)
        {
            if (swipeDelta.magnitude > _minDragingRange && swipeDelta.magnitude < _maxDragingRange)
            {
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    if (swipeDelta.x < 0)
                        DirectionEvent(DirectionType.Left);
                    else
                        DirectionEvent(DirectionType.Right);
                }
                else
                {
                    if (swipeDelta.y < 0)
                        DirectionEvent(DirectionType.Down);
                    else
                        DirectionEvent(DirectionType.Up);
                }
            }
        }
        
        private void DirectionEvent(DirectionType typeDirection)
        {
            OnInputDirection?.Invoke(typeDirection);
        }
    }
}