using Zenject;

namespace Gameplay
{
    public class WeaponPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponPointPresenter>().AsSingle();
        }
    }
}