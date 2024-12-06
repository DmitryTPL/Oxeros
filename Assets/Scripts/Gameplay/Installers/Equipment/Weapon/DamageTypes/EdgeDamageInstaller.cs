using Zenject;

namespace Gameplay
{
    public class EdgeDamageInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EdgeDamagePresenter>().AsSingle();
        }
    }
}