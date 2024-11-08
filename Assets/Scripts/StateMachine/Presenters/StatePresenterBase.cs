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
        private AsyncReactiveProperty<TStateResult> _stateResultChanged;
        private readonly AsyncReactiveProperty<TStateType> _stateChanged = new(default);
        
        protected TStateResult StateResult { get; private set; }
        protected IStateMachine<TStateType> StateMachine { get; private set; }
        protected IPersistentData PersistentData { get; private set; }
        protected ISharedData<TStateType> SharedData { get; private set; }

        public IReadOnlyAsyncReactiveProperty<TStateResult> StateResultChanged => _stateResultChanged;
        public IReadOnlyAsyncReactiveProperty<TStateType> StateChanged => _stateChanged;

        [Inject]
        protected void AddDependencies(TStateResult stateResult, IStateMachine<TStateType> stateMachine, IPersistentData persistentData,
            ISharedData<TStateType> sharedData)
        {
            StateResult = stateResult;
            StateMachine = stateMachine;
            PersistentData = persistentData;
            SharedData = sharedData;

            _stateResultChanged = new AsyncReactiveProperty<TStateResult>(StateResult);

            stateMachine.CurrentState.WithoutCurrent().ForEachAsync(OnStateChanged, DestroyCancellationToken).Forget();
        }

        protected override void InitializeData()
        {
            PersistentData.Guid = Guid;
        }

        protected void UpdateState()
        {
            if (!IsEnable)
            {
                return;
            }

            PreStateUpdate();

            StateMachine.Execute();

            PostStateUpdate();
        }

        protected virtual void PreStateUpdate()
        {
            StateResult.Reset();
        }

        protected virtual void PostStateUpdate()
        {
            ApplyStateDataChanges(StateResult);

            _stateResultChanged.Value = StateResult;
        }

        protected virtual void ApplyStateDataChanges(TStateResult stateResult)
        {
        }

        private void OnStateChanged(TStateType nextState)
        {
            SharedData.CurrentState.Value = nextState;

            _stateChanged.Value = nextState;
        }
    }
}