using Zenject;

namespace Gameplay
{
    public class DieAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DieAbilityPresenter>().AsSingle();
        }
    }
}