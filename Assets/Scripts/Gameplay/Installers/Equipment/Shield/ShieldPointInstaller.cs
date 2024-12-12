using Zenject;

namespace Gameplay
{
    public class ShieldPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShieldPointPresenter>().AsSingle();
        }
    }
}