using Zenject;

namespace Gameplay
{
    public class HitHandlerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HitHandler>().AsSingle();

            Container.BindInterfacesTo<EdgeDamageHandler>().AsSingle();
        }
    }
}