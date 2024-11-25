using Zenject;

namespace Gameplay
{
    public class MobAnimationToStateBindingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MobAnimationHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MobAnimationToStateBindingPresenter>().AsSingle();
        }
    }
}