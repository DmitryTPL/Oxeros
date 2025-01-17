using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DieAbilityPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private GameObject _mesh;

            public GameObject Mesh => _mesh;
        }

        public DieAbilityPresenter()
        {
        }

        [Inject]
        public DieAbilityPresenter(IHealthHandler healthHandler)
        {
            healthHandler.Health.WithoutCurrent().ForEachAsync(HealthChanged, DestroyCancellationToken).Forget();
        }

        private void HealthChanged(float health)
        {
            if (health <= float.Epsilon)
            {
                GetSharedData<Data>().Mesh.SetActive(false);
            }
        }
    }
}