using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface ITeleportationHandler
    {
        IReadOnlyAsyncReactiveProperty<Vector3> TeleportPosition { get; }

        void Teleport(Vector3 position);
    }

    public class TeleportationHandler : ITeleportationHandler
    {
        private readonly AsyncReactiveProperty<Vector3> _teleportPosition = new AsyncReactiveProperty<Vector3>(Vector3.zero);

        public IReadOnlyAsyncReactiveProperty<Vector3> TeleportPosition => _teleportPosition;

        public void Teleport(Vector3 position)
        {
            _teleportPosition.Value = position;
        }
    }
}