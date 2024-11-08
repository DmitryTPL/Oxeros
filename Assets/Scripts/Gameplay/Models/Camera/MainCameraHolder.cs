using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IMainCameraHolder
    {
        AsyncReactiveProperty<Camera> MainCamera { get; set; }
    }

    public class MainCameraHolder : IMainCameraHolder
    {
        public AsyncReactiveProperty<Camera> MainCamera { get; set; } = new(default);
    }
}