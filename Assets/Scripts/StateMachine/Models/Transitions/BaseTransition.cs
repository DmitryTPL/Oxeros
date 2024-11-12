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
        private ITransitionsConfig<TStateType, TTransitionType> _config;

        public abstract TStateType MoveToState { get; }
        public abstract TTransitionType Transition { get; }

        protected bool IsActive => true;
        protected Dictionary<TStateType, Func<bool>> ConditionCheckedInState { get; } = new();

        protected void Initialize(ITransitionsConfig<TStateType, TTransitionType> config, IStateTimingHandler<TStateType> stateDelayHandler)
        {
            _config = config;
            _usedInStates = config.ContainsTransition(Transition) ? config.GetStatesForTransition(Transition) : new List<TStateType>(0);
            _stateDelayHandler = stateDelayHandler;

            FillConditionForStates();
        }

        public bool CanActivate(TStateType inState)
        {
            return IsActive &&
                   (_stateDelayHandler.IsTimePassed(inState) || _config.CanTransitionInterruptStateTiming(inState, Transition)) &&
                   ConditionCheckedInState[inState]();
        }

        protected virtual bool Condition()
        {
            return true;
        }

        protected virtual void FillConditionForStates()
        {
            foreach (var characterState in _usedInStates)
            {
                ConditionCheckedInState[characterState] = Condition;
            }
        }
    }
}