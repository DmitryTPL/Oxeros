using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IGravityForceReaction
    {
        AsyncReactiveProperty<Vector3> GravityForce { get; set; }
    }

    public class GravityForceReaction : IGravityForceReaction
    {
        public AsyncReactiveProperty<Vector3> GravityForce { get; set; } = new(default);
    }
}