using Zenject;

namespace Gameplay
{
    public class ShieldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DamageBlockerPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShieldPresenter>().AsSingle();
        }
    }
}