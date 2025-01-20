using Zenject;

namespace Gameplay
{
    public class HealthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HealthHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthBarPresenter>().AsSingle();
        }
    }
}