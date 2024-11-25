using UnityEngine.InputSystem;

namespace Gameplay
{
    public interface IInputData
    {
        InputAction InputAction { get; set; }
    }

    public abstract class BaseInputData : IInputData
    {
        public InputAction InputAction { get; set; }
    }
}