using Zenject;

namespace Gameplay
{
    public class CharacterRespawnInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterRespawnPresenter>().AsSingle();
        }
    }
}