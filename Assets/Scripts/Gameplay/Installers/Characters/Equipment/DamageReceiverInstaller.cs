using Zenject;

namespace Gameplay
{
    public class DamageReceiverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DamageReceiverPresenter>().AsSingle();
        }
    }
}