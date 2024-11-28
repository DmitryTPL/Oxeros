using Zenject;

namespace Gameplay
{
    public class NoticeEnemyAbilityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NoticeEnemyArea>().AsSingle();
            Container.BindInterfacesAndSelfTo<NoticeEnemyAbilityPresenter>().AsSingle();
        }
    }
}