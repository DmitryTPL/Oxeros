using System;
using System.Collections.Generic;
using StateMachine;

namespace Gameplay
{
    public class CharacterTransitionsHolder : BaseTransitionsHolder<CharacterState, CharacterTransition, ICharacterTransition>, ICharacterTransitionsHolder
    {
        public CharacterTransitionsHolder(List<ICharacterTransition> transitions, CharacterTransitionsConfig transitionsConfig)
            : base(transitions, transitionsConfig)
        {
        }
        
        protected override bool CompareTransitions(Enum transition1, Enum transition2)
        {
            return (CharacterTransition)transition1 == (CharacterTransition)transition2;
        }
    }
}