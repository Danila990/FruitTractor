using System;
using Enums;

namespace Services
{
    public interface IInputService
    {
        public event Action<TypeDirection> OnInputDirection;
    }
}