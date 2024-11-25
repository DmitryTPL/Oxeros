using StateMachine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseCharacterState : BaseStateWithTransitions<CharacterState, CharacterTransition, ICharacterTransition, ICharacterTransitionsHolder,
        ICharacterStateTimingHandler, CharacterStateTimeConfig, CharacterStateToTimeDictionary>, ICharacterState
    {
        protected CharacterConfig Config { get; private set; }

        [Inject]
        public void AddDependencies(CharacterConfig config)
        {
            Config = config;
        }
    }
}