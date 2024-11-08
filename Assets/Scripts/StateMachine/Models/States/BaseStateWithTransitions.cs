using System;
using AYellowpaper.SerializedCollections;
using Cysharp.Threading.Tasks;
using Zenject;

namespace StateMachine
{
    public abstract class BaseStateWithTransitions<TStateType, TTransitionType, TTransition, TTransitionsHolder,
        TStateTimingHandler, TStateTimingConfig, TStateToDelayDictionary, TStateResult> : BaseState<TStateType>
        where TStateType : Enum
        where TTransitionType : Enum
        where TTransition : ITransition<TStateType, TTransitionType>
        where TTransitionsHolder : ITransitionsHolder<TStateType, TTransitionType, TTransition>
        where TStateTimingHandler : IStateTimingHandler<TStateType>
        where TStateTimingConfig : BaseStateTimeConfig<TStateType, TStateToDelayDictionary>
        where TStateToDelayDictionary : SerializedDictionary<TStateType, float>
        where TStateResult : IStateResult
    {
        private TTransitionsHolder _transitionsHolder;

        protected TStateTimingHandler StateTimingHandler { get; private set; }
        protected TStateTimingConfig StateTimeConfig { get; private set; }
        protected TStateResult StateResult { get; private set; }

        [Inject]
        public void AddDependenciesBase(TTransitionsHolder transitionsHolder, TStateTimingHandler stateTimingHandler,
            TStateTimingConfig stateTimeConfig, TStateResult stateResult)
        {
            _transitionsHolder = transitionsHolder;

            StateTimingHandler = stateTimingHandler;
            StateTimeConfig = stateTimeConfig;
            StateResult = stateResult;
        }

        public override UniTask Enter()
        {
            StateTimingHandler.SetTiming(State, StateTimeConfig.GetDelay(State));

            return base.Enter();
        }

        protected override async UniTask<TStateType> TryMakeTransition()
        {
            foreach (var transition in _transitionsHolder.GetTransitions(State))
            {
                if (transition.CanActivate(State))
                {
                    return transition.MoveToState;
                }
            }

            return await base.TryMakeTransition();
        }
    }
}