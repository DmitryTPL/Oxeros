using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class LookAtCameraPresenter : Presenter
    {
        private Camera _camera;

        public Camera MainCamera => _camera;

        public bool IsCameraActive { get; private set; }

        public LookAtCameraPresenter() { }

        [Inject]
        public LookAtCameraPresenter(IMainCameraHolder mainCameraHolder)
        {
            mainCameraHolder.MainCamera.ForEachAsync(MainCameraChanged, DestroyCancellationToken).Forget();
        }

        private void MainCameraChanged(Camera camera)
        {
            _camera = camera;

            IsCameraActive = _camera != null;
        }
    }
}