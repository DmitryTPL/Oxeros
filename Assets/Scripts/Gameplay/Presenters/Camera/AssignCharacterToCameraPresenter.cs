using System;
using Cinemachine;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AssignCharacterToCameraPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private CinemachineVirtualCamera _virtualCamera;

            public CinemachineVirtualCamera VirtualCamera => _virtualCamera;
        }

        private readonly IRespawnHandler _respawnHandler;

        public AssignCharacterToCameraPresenter() { }

        [Inject]
        public AssignCharacterToCameraPresenter(IRespawnHandler respawnHandler)
        {
            respawnHandler.FirstSpawnFinished.WithoutCurrent().ForEachAsync(CharacterAppeared, DestroyCancellationToken);
        }

        private void CharacterAppeared(Transform transform)
        {
            var data = GetSharedData<Data>();

            data.VirtualCamera.LookAt = transform;
            data.VirtualCamera.Follow = transform;
        }
    }
}