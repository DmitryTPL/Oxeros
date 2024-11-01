using System;

namespace StateMachine
{
    public class TransitionAttribute : Attribute
    {
        public int Transition { get; }

        public TransitionAttribute(int transition)
        {
            Transition = transition;
        }
    }
}