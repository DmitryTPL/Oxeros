using Zenject;

namespace Gameplay
{
    public class RotateReactionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<RotateReaction>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotateReactionPresenter>().AsSingle();
        }
    }
}