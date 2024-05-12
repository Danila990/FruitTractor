using System;
using UnityEngine;

namespace Code
{
    public class PcInputService : MonoBehaviour, IInputService
    {
        public event Action<DirectionType> OnInputDirection;
        
        private void Update() => Inputs();

        private void Inputs()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0)
            {
                if (x > 0)
                    DirectionEvent(DirectionType.Right);
                else
                    DirectionEvent(DirectionType.Left);
                
                return;
            }
            
            if (y != 0)
            {
                if (y > 0)
                    DirectionEvent(DirectionType.Up);
                else
                    DirectionEvent(DirectionType.Down);

            }
        }

        private void DirectionEvent(DirectionType typeDirection)
        {
            OnInputDirection?.Invoke(typeDirection);
        }
    }
}