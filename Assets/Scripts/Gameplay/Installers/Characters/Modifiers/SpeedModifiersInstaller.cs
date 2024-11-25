using Zenject;

namespace Gameplay
{
    public class SpeedModifiersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SpeedModifiersHolder>().AsSingle();
        }
    }
}