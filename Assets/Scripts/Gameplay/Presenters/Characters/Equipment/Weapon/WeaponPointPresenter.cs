using System;
using MVP;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gameplay
{
    public class WeaponPointPresenter : Presenter
    {
        private readonly IViewFactory _viewFactory;

        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private GameObject _defaultWeaponPrefab;

            public GameObject DefaultWeaponPrefab => _defaultWeaponPrefab;
        }

        private Data _data;

        public WeaponPointPresenter()
        {
        }

        [Inject]
        public WeaponPointPresenter(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();

            var weapon = _viewFactory.Create(_data.DefaultWeaponPrefab);

            weapon.transform.SetParent(_data.Transform, false);
        }
    }
}