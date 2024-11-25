using Zenject;

namespace Gameplay
{
    public class RotateAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<RotateAbility>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotateAbilityPresenter>().AsSingle();
        }
    }
}