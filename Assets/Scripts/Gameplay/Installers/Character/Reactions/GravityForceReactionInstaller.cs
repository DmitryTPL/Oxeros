using Zenject;

namespace Gameplay
{
    public class GravityForceReactionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GravityForceReaction>().AsSingle();
        }
    }
}