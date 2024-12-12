using System;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class EquipmentPointPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private GameObject _defaultEquipmentPrefab;

            public GameObject DefaultEquipmentPrefab => _defaultEquipmentPrefab;
        }

        private Data _data;
        private IViewFactory _viewFactory;

        [Inject]
        public void AddDependencies(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory; 
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();

            var equipment = _viewFactory.Create(_data.DefaultEquipmentPrefab);

            equipment.transform.SetParent(_data.Transform, false);
        }
    }
}