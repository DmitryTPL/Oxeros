using System;
using System.Collections.Generic;

namespace StateMachine
{
    public interface ITransition<TStateType, out TTransitionType>
        where TStateType : Enum
        where TTransitionType : Enum
    {
        TTransitionType Transition { get; }
        TStateType MoveToState { get; }

        bool CanActivate(TStateType inState);
    }

    public abstract class BaseTransition<TStateType, TTransitionType> : ITransition<TStateType, TTransitionType>
        where TStateType : Enum
        where TTransitionType : Enum
    {
        private IStateTimingHandler<TStateType> _stateDelayHandler;
        private IEnumerable<TStateType> _usedInStates;
        private ITransitionsActivityHandler<TTransitionType> _transitionsActivityHandler;
        private ITransitionsConfig<TStateType, TTransitionType> _config;

        protected readonly Dictionary<TStateType, Func<bool>> _conditionCheckedInState = new();

        public abstract TStateType MoveToState { get; }
        public abstract TTransitionType Transition { get; }

        protected ITransitionsActivityHandler<TTransitionType> TransitionsActivityHandler => _transitionsActivityHandler;

        protected void Initialize(ITransitionsActivityHandler<TTransitionType> transitionsActivityHandler,
            ITransitionsConfig<TStateType, TTransitionType> config, IStateTimingHandler<TStateType> stateDelayHandler)
        {
            _config = config;
            _transitionsActivityHandler = transitionsActivityHandler;
            _usedInStates = config.ContainsTransition(Transition) ? config.GetStatesForTransition(Transition) : new List<TStateType>(0);
            _stateDelayHandler = stateDelayHandler;

            FillConditionForStates();
        }

        public bool CanActivate(TStateType inState)
        {
            return _transitionsActivityHandler.IsTransitionActive(Transition) &&
                   (_stateDelayHandler.IsTimePassed(inState) || _config.CanTransitionInterruptStateTiming(inState, Transition)) &&
                   _conditionCheckedInState[inState]();
        }

        protected virtual bool Condition()
        {
            return true;
        }

        protected virtual void FillConditionForStates()
        {
            foreach (var characterState in _usedInStates)
            {
                _conditionCheckedInState[characterState] = Condition;
            }
        }
    }
}