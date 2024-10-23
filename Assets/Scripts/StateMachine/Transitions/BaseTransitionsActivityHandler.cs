using System;
using System.Collections.Generic;

namespace StateMachine
{
    public interface ITransitionsActivityHandler<in TTransitionType>
        where TTransitionType : Enum
    {
        bool IsTransitionActive(TTransitionType transition);
    }
    
    public abstract class BaseTransitionsActivityHandler<TStateType, TTransitionType> : ITransitionsActivityHandler<TTransitionType>
        where TStateType : Enum
        where TTransitionType : Enum
    {
        protected readonly HashSet<TTransitionType> _activeTransitions = new();

        protected BaseTransitionsActivityHandler(ITransitionsConfig<TStateType, TTransitionType> config)
        {
            foreach (var activeTransition in config.GetActiveTransitions())
            {
                _activeTransitions.Add(activeTransition);
            }
        }

        public bool IsTransitionActive(TTransitionType transition)
        {
            return _activeTransitions.Contains(transition);
        }
    }
}