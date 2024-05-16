using System;
using UnityEngine;

namespace Code
{
    public class MobileInputService : MonoBehaviour, IInputService
    {
        public event Action<DirectionType> OnInputDirection;
        
        private readonly int _minDragingRange = 125;
        private readonly int _maxDragingRange = 1000;

        private Vector2 _startTouch;

        private void Update() 
        {
            Inputs();
        }

        public void InvokeInputEvent(DirectionType direction)
        {
            OnInputDirection?.Invoke(direction);
        }

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
                        InvokeInputEvent(DirectionType.Left);
                    else
                        InvokeInputEvent(DirectionType.Right);
                }
                else
                {
                    if (swipeDelta.y < 0)
                        InvokeInputEvent(DirectionType.Down);
                    else
                        InvokeInputEvent(DirectionType.Up);
                }
            }
        }
    }
}