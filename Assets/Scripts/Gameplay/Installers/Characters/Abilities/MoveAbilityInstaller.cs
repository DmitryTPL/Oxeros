using Zenject;

namespace Gameplay
{
    public class MoveAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveAbility>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveAbilityPresenter>().AsSingle();
        }
    }
}