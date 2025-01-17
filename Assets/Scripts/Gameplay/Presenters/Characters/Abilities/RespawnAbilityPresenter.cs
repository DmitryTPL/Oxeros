using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RespawnAbilityPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Transform _root;
            [SerializeField] private GameObject _mesh;

            public Transform Root => _root;
            public GameObject Mesh => _mesh;
        }

        public RespawnAbilityPresenter() { }

        [Inject]
        public RespawnAbilityPresenter(IRespawnAbility respawnAbility)
        {
            respawnAbility.Respawn.WithoutCurrent().ForEachAsync(Respawn, DestroyCancellationToken).Forget();
        }

        private void Respawn(Vector3 position)
        {
            var data = GetSharedData<Data>();

            data.Mesh.SetActive(true);
            data.Root.position = position;
        }
    }
}