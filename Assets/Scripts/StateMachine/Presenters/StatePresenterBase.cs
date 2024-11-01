using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using Zenject;

namespace StateMachine
{
    public abstract class StatePresenterBase<TStateResult, TStateType> : Presenter
        where TStateResult : IStateResult
        where TStateType : Enum
    {
        protected TStateResult _stateResult;
        protected IStateMachine<TStateType> _stateMachine;
        protected IPersistentData _persistentData;
        protected AsyncReactiveProperty<TStateResult> _stateResultChanged;
        protected readonly AsyncReactiveProperty<TStateType> _stateChanged = new(default);
        protected ISharedData<TStateType> _sharedData;

        public IReadOnlyAsyncReactiveProperty<TStateResult> StateResultChanged => _stateResultChanged;
        public IReadOnlyAsyncReactiveProperty<TStateType> StateChanged => _stateChanged;

        [Inject]
        protected void AddDependencies(TStateResult stateResult, IStateMachine<TStateType> stateMachine, IPersistentData persistentData,
            ISharedData<TStateType> sharedData)
        {
            _stateResult = stateResult;
            _stateMachine = stateMachine;
            _stateResultChanged = new AsyncReactiveProperty<TStateResult>(_stateResult);
            _persistentData = persistentData;
            _sharedData = sharedData;

            stateMachine.CurrentState.WithoutCurrent().ForEachAsync(OnStateChanged, DestroyCancellationToken).Forget();
        }

        protected override void InitializeData()
        {
            _persistentData.Guid = Guid;
        }

        protected void UpdateState()
        {
            if (!IsEnable)
            {
                return;
            }

            PreStateUpdate();

            _stateMachine.Execute();

            PostStateUpdate();
        }

        protected virtual void PreStateUpdate()
        {
            _stateResult.Reset();
        }

        protected virtual void PostStateUpdate()
        {
            ApplyStateDataChanges(_stateResult);

            _stateResultChanged.Value = _stateResult;
        }

        protected virtual void ApplyStateDataChanges(TStateResult stateResult)
        {
        }

        private void OnStateChanged(TStateType nextState)
        {
            _sharedData.CurrentState.Value = nextState;
            
            _stateChanged.Value = nextState;
        }
    }
}