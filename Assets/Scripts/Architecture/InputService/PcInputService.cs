using System;
using UnityEngine;

namespace Code
{
    public class PcInputService : MonoBehaviour, IInputService
    {
        public event Action<DirectionType> OnInputDirection;

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
            if (Input.GetKeyDown(KeyCode.D))
            {
                InvokeInputEvent(DirectionType.Right);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                InvokeInputEvent(DirectionType.Left);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                InvokeInputEvent(DirectionType.Up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                InvokeInputEvent(DirectionType.Down);
            }  
        }
    }
}