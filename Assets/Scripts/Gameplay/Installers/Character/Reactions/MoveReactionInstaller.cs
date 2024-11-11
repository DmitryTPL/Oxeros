using Zenject;

namespace Gameplay
{
    public class MoveReactionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveReaction>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveReactionPresenter>().AsSingle();
        }
    }
}