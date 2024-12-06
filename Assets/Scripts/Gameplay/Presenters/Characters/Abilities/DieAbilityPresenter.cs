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
            [SerializeField] private GameObject _root;

            public GameObject Root => _root;
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
                GetSharedData<Data>().Root.gameObject.SetActive(false);
            }
        }
    }
}