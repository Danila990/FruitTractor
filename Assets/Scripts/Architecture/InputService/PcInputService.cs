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
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0)
            {
                if (x > 0)
                    InvokeInputEvent(DirectionType.Right);
                else
                    InvokeInputEvent(DirectionType.Left);
                
                return;
            }
            
            if (y != 0)
            {
                if (y > 0)
                    InvokeInputEvent(DirectionType.Up);
                else
                    InvokeInputEvent(DirectionType.Down);

            }
        }
    }
}