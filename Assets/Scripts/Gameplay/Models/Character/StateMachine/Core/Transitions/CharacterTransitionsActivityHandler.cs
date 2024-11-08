using StateMachine;

namespace Gameplay
{
    public class CharacterTransitionsActivityHandler : BaseTransitionsActivityHandler<CharacterState, CharacterTransition>, ICharacterTransitionsActivityHandler
    {
        public CharacterTransitionsActivityHandler(CharacterTransitionsConfig config)
            : base(config)
        {
        }
    }
}