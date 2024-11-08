using Zenject;

namespace Gameplay
{
    public class MoveStateReactionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveStateReaction>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveStateReactionPresenter>().AsSingle();
        }
    }
}