using System;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MainCameraPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Camera _camera;

            public Camera Camera => _camera;
        }

        private readonly IMainCameraHolder _mainCameraHolder;

        public MainCameraPresenter() { }

        [Inject]
        public MainCameraPresenter(IMainCameraHolder mainCameraHolder)
        {
            _mainCameraHolder = mainCameraHolder;
        }

        protected override void InitializeData()
        {
            _mainCameraHolder.MainCamera.Value = GetSharedData<Data>().Camera;
        }
    }
}