using Zenject;

namespace Gameplay
{
    public class CharacterUnityEventToStateBindingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterUnityEventToStateBindingPresenter>().AsSingle();
        }
    }
}