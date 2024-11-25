using Zenject;

namespace Gameplay
{
    public class GravityAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GravityAbility>().AsSingle();
        }
    }
}