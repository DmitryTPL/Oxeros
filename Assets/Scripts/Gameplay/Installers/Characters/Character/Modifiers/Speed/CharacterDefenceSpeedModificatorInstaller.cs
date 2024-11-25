using Zenject;

namespace Gameplay
{
    public class CharacterDefenceSpeedModificatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CharacterDefenceSpeedModificator>().AsSingle();
        }
    }
}