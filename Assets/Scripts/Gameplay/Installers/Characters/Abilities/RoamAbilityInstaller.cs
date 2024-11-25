using Zenject;

namespace Gameplay
{
    public class RoamAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<RoamBoxArea>().AsSingle();
            Container.BindInterfacesAndSelfTo<RoamAbilityPresenter>().AsSingle();
        }
    }
}