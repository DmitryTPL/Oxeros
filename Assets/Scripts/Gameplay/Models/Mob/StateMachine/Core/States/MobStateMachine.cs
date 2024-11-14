using System.Collections.Generic;
using StateMachine;

namespace Gameplay
{
    public class MobStateMachine : BaseStateMachine<IMobState, MobState>, IMobStateMachine
    {
        public MobStateMachine(List<IMobState> states) : base(states)
        {
        }
    }
}