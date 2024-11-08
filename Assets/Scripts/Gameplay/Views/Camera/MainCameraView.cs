using MVP;
using UnityEngine;

namespace Gameplay
{
    public class MainCameraView : View<MainCameraPresenter>
    {
        [SerializeField] private MainCameraPresenter.Data _data;

        protected override PresenterViewSharedData SharedData => _data;
    }
}