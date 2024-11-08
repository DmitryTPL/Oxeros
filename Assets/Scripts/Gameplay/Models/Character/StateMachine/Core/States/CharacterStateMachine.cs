using System.Collections.Generic;
using StateMachine;

namespace Gameplay
{
    public class CharacterStateMachine : BaseStateMachine<ICharacterState, CharacterState>, ICharacterStateMachine
    {
        public CharacterStateMachine(List<ICharacterState> states) : base(states)
        {
        }
    }
}