using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IMoveReaction
    {
        AsyncReactiveProperty<Vector3> Acceleration { get; }
    }

    public class MoveReaction : IMoveReaction
    {
        public AsyncReactiveProperty<Vector3> Acceleration { get; } = new(default);
    }
}