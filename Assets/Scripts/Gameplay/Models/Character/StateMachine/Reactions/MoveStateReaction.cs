using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IMoveStateReaction
    {
        AsyncReactiveProperty<Vector3> Acceleration { get; set; }
    }

    public class MoveStateReaction : IMoveStateReaction
    {
        public AsyncReactiveProperty<Vector3> Acceleration { get; set; } = new(default);
    }
}