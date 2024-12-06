using Zenject;

namespace Gameplay
{
    public class MobUnityEventToStateBindingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MobUnityEventToStateBindingPresenter>().AsSingle();
        }
    }
}