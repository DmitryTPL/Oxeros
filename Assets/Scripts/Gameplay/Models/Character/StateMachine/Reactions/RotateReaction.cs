using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IRotateReaction
    {
        AsyncReactiveProperty<Vector3> Rotation { get; }
        AsyncReactiveProperty<bool> Stop { get; }
    }

    public class RotateReaction : IRotateReaction
    {
        public AsyncReactiveProperty<Vector3> Rotation { get; } = new(default);
        public AsyncReactiveProperty<bool> Stop { get; } = new(default);
    }
}