using System;
using Zenject;

namespace Gameplay
{
    [Serializable]
    public class MobInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(destroyCancellationToken).AsCached();
        
            Container.BindInterfacesAndSelfTo<MobPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<MobStateChangeObserverPresenter>().AsSingle();
        
            InstallStateMachine();
            InstallTransitions();
        }
        
        private void InstallStateMachine()
        {
            Container.BindInterfacesTo<MobStateMachine>().AsSingle();
            Container.BindInterfacesTo<MobStateTimingHandler>().AsSingle();
            Container.BindInterfacesTo<MobPersistentData>().AsSingle();
            Container.BindInterfacesTo<MobPerUpdateData>().AsSingle();
            Container.BindInterfacesTo<MobSharedData>().AsSingle();
        
            Container.BindInterfacesTo<IdleMobState>().AsSingle();
        }
        
        private void InstallTransitions()
        {
            Container.BindInterfacesTo<MobTransitionsHolder>().AsSingle();
        
            Container.BindInterfacesTo<IdleMobTransition>().AsSingle();
        }
    }
}