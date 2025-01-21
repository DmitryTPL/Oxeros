using Zenject;

namespace Gameplay
{
    public class DefenceHandlerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DefenceHandler>().AsSingle();
        }
    }
}