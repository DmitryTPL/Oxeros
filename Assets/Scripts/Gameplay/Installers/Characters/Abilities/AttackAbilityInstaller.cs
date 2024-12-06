using Zenject;

namespace Gameplay
{
    public class AttackAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AttackAbility>().AsSingle();
        }
    }
}