using Zenject;

namespace Gameplay
{
    public class SceneLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ViewFactory>().AsSingle();
            Container.BindInterfacesTo<RespawnHandler>().AsSingle();
            Container.BindInterfacesTo<TeleportationHandler>().AsSingle();
            Container.BindInterfacesTo<CharacterDeathHandler>().AsSingle();
        }
    }
}