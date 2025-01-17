using Zenject;

namespace Gameplay
{
    public class AssignCharacterToCameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AssignCharacterToCameraPresenter>().AsSingle();
        }
    }
}