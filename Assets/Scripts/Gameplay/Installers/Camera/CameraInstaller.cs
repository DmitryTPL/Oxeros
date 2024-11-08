using Zenject;

namespace Gameplay
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MainCameraHolder>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainCameraPresenter>().AsSingle();
        }
    }
}