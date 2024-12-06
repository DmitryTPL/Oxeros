using Zenject;

namespace Gameplay
{
    public class ViewFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ViewFactory>().AsCached();
        }
    }
}