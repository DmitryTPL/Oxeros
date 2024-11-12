using StateMachine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseCharacterTransition : BaseTransition<CharacterState, CharacterTransition>, ICharacterTransition
    {
        [Inject]
        public void AddDependencies(CharacterTransitionsConfig config, ICharacterStateTimingHandler stateDelayHandler)
        {
            Initialize(config, stateDelayHandler);
        }
    }
}