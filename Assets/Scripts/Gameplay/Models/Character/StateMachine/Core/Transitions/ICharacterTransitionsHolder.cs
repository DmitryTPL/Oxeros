using StateMachine;

namespace Gameplay
{
    public interface ICharacterTransitionsHolder : ITransitionsHolder<CharacterState, CharacterTransition, ICharacterTransition>
    {
    }
}