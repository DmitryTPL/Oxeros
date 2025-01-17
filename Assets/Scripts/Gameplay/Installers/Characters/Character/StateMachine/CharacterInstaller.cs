using System;
using Zenject;

namespace Gameplay
{
    [Serializable]
    public class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(destroyCancellationToken).AsCached();
            Container.BindInterfacesTo<ViewFactory>().AsCached();

            Container.BindInterfacesAndSelfTo<CharacterPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterStateChangeObserverPresenter>().AsSingle();

            InstallStateMachine();
            InstallTransitions();
        }

        private void InstallStateMachine()
        {
            Container.BindInterfacesTo<CharacterStateMachine>().AsSingle();
            Container.BindInterfacesTo<CharacterStateTimingHandler>().AsSingle();
            Container.BindInterfacesTo<CharacterPersistentData>().AsSingle();
            Container.BindInterfacesTo<CharacterPerUpdateData>().AsSingle();
            Container.BindInterfacesTo<CharacterSharedData>().AsSingle();

            Container.BindInterfacesTo<IdleCharacterState>().AsSingle();
            Container.BindInterfacesTo<MoveCharacterState>().AsSingle();
            Container.BindInterfacesTo<AttackCharacterState>().AsSingle();
            Container.BindInterfacesTo<BeginDefenceCharacterState>().AsSingle();
            Container.BindInterfacesTo<EndDefenceCharacterState>().AsSingle();
            Container.BindInterfacesTo<DeathCharacterState>().AsSingle();
            Container.BindInterfacesTo<RespawnCharacterState>().AsSingle();
        }

        private void InstallTransitions()
        {
            Container.BindInterfacesTo<CharacterTransitionsHolder>().AsSingle();

            Container.BindInterfacesTo<IdleCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<MoveCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<AttackCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<BeginDefenceCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<EndDefenceCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<DeathCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<RespawnCharacterTransition>().AsSingle();
        }
    }
}