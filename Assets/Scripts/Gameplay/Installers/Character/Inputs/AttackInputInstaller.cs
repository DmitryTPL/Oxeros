using Zenject;

namespace Gameplay
{
    public class AttackInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AttackInputData>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackInputPresenter>().AsSingle();
        }
    }
}