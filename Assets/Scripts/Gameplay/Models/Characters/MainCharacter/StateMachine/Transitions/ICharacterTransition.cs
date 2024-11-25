using StateMachine;

namespace Gameplay
{
    public interface ICharacterTransition : ITransition<CharacterState, CharacterTransition>
    {
    }
}