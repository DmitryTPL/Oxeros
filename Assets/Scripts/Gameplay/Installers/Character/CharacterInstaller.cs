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

            Container.BindInterfacesAndSelfTo<CharacterPresenter>().AsSingle();

            InstallStateMachine();
            InstallTransitions();
        }

        private void InstallStateMachine()
        {
            Container.BindInterfacesTo<CharacterStateMachine>().AsSingle();
            Container.BindInterfacesTo<CharacterStateTimingHandler>().AsSingle();
            Container.BindInterfacesTo<CharacterStateResult>().AsSingle();
            Container.BindInterfacesTo<CharacterPersistentData>().AsSingle();
            Container.BindInterfacesTo<CharacterPerUpdateData>().AsSingle();
            Container.BindInterfacesTo<CharacterSharedData>().AsSingle();

            Container.BindInterfacesTo<IdleCharacterState>().AsSingle();
            Container.BindInterfacesTo<MoveCharacterState>().AsSingle();
            Container.BindInterfacesTo<AttackCharacterState>().AsSingle();
        }

        private void InstallTransitions()
        {
            Container.BindInterfacesTo<CharacterTransitionsHolder>().AsSingle();

            Container.BindInterfacesTo<IdleCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<MoveCharacterTransition>().AsSingle();
            Container.BindInterfacesTo<AttackCharacterTransition>().AsSingle();
        }
    }
}