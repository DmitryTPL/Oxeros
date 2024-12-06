using Zenject;

namespace Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponPresenter>().AsSingle();
        }
    }
}