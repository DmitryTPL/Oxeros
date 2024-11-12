using Zenject;

namespace Gameplay
{
    public class BaseInputInstaller<TInputData, TInputPresenter> : MonoInstaller
        where TInputData: BaseInputData
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TInputData>().AsSingle();
            Container.BindInterfacesAndSelfTo<TInputPresenter>().AsSingle();
        }
    }
}