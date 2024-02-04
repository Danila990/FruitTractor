using System;
using Enums;
using UnityEngine;

namespace Services
{
    public class PcInputService : MonoBehaviour, IInputService
    {
        public event Action<TypeDirection> OnInputDirection;
        
        private void Update() => Inputs();

        private void Inputs()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0)
            {
                if (x > 0)
                    DirectionEvent(TypeDirection.Right);
                else
                    DirectionEvent(TypeDirection.Left);
                
                return;
            }
            
            if (y != 0)
            {
                if (y > 0)
                    DirectionEvent(TypeDirection.Up);
                else
                    DirectionEvent(TypeDirection.Down);

            }
        }

        private void DirectionEvent(TypeDirection typeDirection)
        {
            OnInputDirection?.Invoke(typeDirection);
        }
    }
}