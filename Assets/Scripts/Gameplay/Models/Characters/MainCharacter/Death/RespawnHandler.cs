using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public interface IRespawnHandler
    {
        Vector3 LastActiveRespawnPosition { get; set; }

        IReadOnlyAsyncReactiveProperty<Transform> FirstSpawnFinished { get; }

        void FinishFirstSpawn(Transform character);
    }

    public class RespawnHandler : IRespawnHandler
    {
        private readonly AsyncReactiveProperty<Transform> _firstSpawnFinished = new(default);

        public IReadOnlyAsyncReactiveProperty<Transform> FirstSpawnFinished => _firstSpawnFinished;
        public Vector3 LastActiveRespawnPosition { get; set; }

        public void FinishFirstSpawn(Transform character)
        {
            _firstSpawnFinished.Value = character;
        }
    }
}