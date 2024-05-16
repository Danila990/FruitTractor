using System;

namespace Code
{
    public interface IInputService
    {
        public event Action<DirectionType> OnInputDirection;

        public void InvokeInputEvent(DirectionType direction);
    }
}