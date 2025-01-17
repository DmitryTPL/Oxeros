using Zenject;

namespace Gameplay
{
    public class RespawnAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RespawnAbilityPresenter>().AsSingle();
            Container.BindInterfacesTo<RespawnAbility>().AsSingle();
        }
    }
}