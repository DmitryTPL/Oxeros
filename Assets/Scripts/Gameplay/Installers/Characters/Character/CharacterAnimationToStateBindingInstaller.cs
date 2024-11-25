using Zenject;

namespace Gameplay
{
    public class CharacterAnimationToStateBindingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterAnimationHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterAnimationToStateBindingPresenter>().AsSingle();
        }
    }
}