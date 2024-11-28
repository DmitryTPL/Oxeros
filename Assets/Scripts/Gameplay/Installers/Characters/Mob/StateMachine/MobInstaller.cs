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
            Container.BindInterfacesTo<RoamMobState>().AsSingle();
            Container.BindInterfacesTo<NoticeMobState>().AsSingle();
            Container.BindInterfacesTo<RotateToTargetMobState>().AsSingle();
            Container.BindInterfacesTo<ApproachTargetMobState>().AsSingle();
            Container.BindInterfacesTo<AttackMobState>().AsSingle();
            Container.BindInterfacesTo<AttackPauseMobState>().AsSingle();
            Container.BindInterfacesTo<ReturnToRoamAreaMobState>().AsSingle();
            Container.BindInterfacesTo<RoamRotationMobState>().AsSingle();
            Container.BindInterfacesTo<WaitForTargetMobState>().AsSingle();
        }

        private void InstallTransitions()
        {
            Container.BindInterfacesTo<MobTransitionsHolder>().AsSingle();

            Container.BindInterfacesTo<IdleMobTransition>().AsSingle();
            Container.BindInterfacesTo<RoamMobTransition>().AsSingle();
            Container.BindInterfacesTo<NoticeMobTransition>().AsSingle();
            Container.BindInterfacesTo<RotateToTargetMobTransition>().AsSingle();
            Container.BindInterfacesTo<ApproachTargetMobTransition>().AsSingle();
            Container.BindInterfacesTo<AttackMobTransition>().AsSingle();
            Container.BindInterfacesTo<AttackPauseMobTransition>().AsSingle();
            Container.BindInterfacesTo<ReturnToRoamAreaMobTransition>().AsSingle();
            Container.BindInterfacesTo<RoamRotationMobTransition>().AsSingle();
            Container.BindInterfacesTo<WaitForTargetMobTransition>().AsSingle();
        }
    }
}