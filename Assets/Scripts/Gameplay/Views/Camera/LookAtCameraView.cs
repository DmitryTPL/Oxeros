using MVP;

namespace Gameplay
{
    public class LookAtCameraView : View<LookAtCameraPresenter>
    {
        public void Update()
        {
            if (Presenter is not { IsCameraActive: true })
            {
                return;
            }

            transform.LookAt(Presenter.MainCamera.gameObject.transform.position);
        }
    }
}