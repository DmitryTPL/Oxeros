using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IRespawnAbility
    {
        IReadOnlyAsyncReactiveProperty<Vector3> Respawn { get; }

        void RespawnOnPosition(Vector3 position);
    }

    public class RespawnAbility : IRespawnAbility
    {
        private readonly AsyncReactiveProperty<Vector3> _respawn = new(default);

        public IReadOnlyAsyncReactiveProperty<Vector3> Respawn => _respawn;
        
        public void RespawnOnPosition(Vector3 position)
        {
            _respawn.Value = position;
        }
    }
}