using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ShieldPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Collider _collider;

            public Collider Collider => _collider;
        }

        private readonly IDefenceHandler _defenceHandler;

        public ShieldPresenter() { }

        [Inject]
        public ShieldPresenter(IDefenceHandler defenceHandler)
        {
            defenceHandler.IsDefending.WithoutCurrent().ForEachAsync(DefendingChanged, DestroyCancellationToken).Forget();
        }

        private void DefendingChanged(bool isDefending)
        {
            var data = GetSharedData<Data>();

            data.Collider.enabled = isDefending;
        }
    }
}