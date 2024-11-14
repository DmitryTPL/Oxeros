using System;
using System.Collections.Generic;
using StateMachine;

namespace Gameplay
{
    public class MobTransitionsHolder : BaseTransitionsHolder<MobState, MobTransition, IMobTransition>, IMobTransitionsHolder
    {
        public MobTransitionsHolder(List<IMobTransition> transitions, MobTransitionsConfig transitionsConfig)
            : base(transitions, transitionsConfig)
        {
        }
        
        protected override bool CompareTransitions(Enum transition1, Enum transition2)
        {
            return (MobTransition)transition1 == (MobTransition)transition2;
        }
    }
}