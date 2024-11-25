using System;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RoamAbilityPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Collider _areaCollider;
            [SerializeField] private float _minPathLength = 1;

            public Collider AreaCollider => _areaCollider;
            public float MinPathLength => _minPathLength;
        }

        private readonly IRoamArea _roamArea;

        public RoamAbilityPresenter() { }

        [Inject]
        public RoamAbilityPresenter(IRoamArea roamArea)
        {
            _roamArea = roamArea;
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            var data = GetSharedData<Data>();

            _roamArea.Init(data.AreaCollider, data.MinPathLength);
        }
    }
}