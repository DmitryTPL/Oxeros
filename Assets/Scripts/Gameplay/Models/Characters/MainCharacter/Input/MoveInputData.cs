using UnityEngine;

namespace Gameplay
{
    public interface IMoveInputData : IInputData
    {
        public Vector3 Value { get; }
    }

    public class MoveInputData : BaseInputData, IMoveInputData
    {
        private readonly IMainCameraHolder _mainCameraHolder;

        public MoveInputData(IMainCameraHolder mainCameraHolder)
        {
            _mainCameraHolder = mainCameraHolder;
        }

        public Vector3 Value
        {
            get
            {
                if (_mainCameraHolder.MainCamera == null)
                {
                    return Vector3.zero;
                }

                var moveContext = InputAction.ReadValue<Vector2>().normalized;
                return Quaternion.Euler(0, _mainCameraHolder.MainCamera.Value.transform.eulerAngles.y, 0) * new Vector3(moveContext.x, 0, moveContext.y);
            }
        }
    }
}