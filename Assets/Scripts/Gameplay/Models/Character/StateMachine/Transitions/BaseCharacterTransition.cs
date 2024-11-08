using StateMachine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseCharacterTransition : BaseTransition<CharacterState, CharacterTransition>, ICharacterTransition
    {
        [Inject]
        public void AddDependencies(ICharacterTransitionsActivityHandler abilitiesActivityHandler,
            CharacterTransitionsConfig config, ICharacterStateTimingHandler stateDelayHandler)
        {
            Initialize(abilitiesActivityHandler, config, stateDelayHandler);
        }
    }
}