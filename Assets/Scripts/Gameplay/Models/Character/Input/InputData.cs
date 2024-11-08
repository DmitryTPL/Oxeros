using UnityEngine.InputSystem;

namespace Gameplay
{
    public interface IInputData
    {
        InputAction InputAction { get; set; }
    }

    public abstract class InputData : IInputData
    {
        public InputAction InputAction { get; set; }
    }
}