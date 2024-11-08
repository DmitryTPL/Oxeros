using Zenject;

namespace Gameplay
{
    public class MoveInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveInputData>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveInputPresenter>().AsSingle();
        }
    }
}