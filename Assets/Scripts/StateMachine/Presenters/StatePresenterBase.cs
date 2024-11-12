using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using Zenject;

namespace StateMachine
{
    public abstract class StatePresenterBase<TStateType> : Presenter
        where TStateType : Enum
    {
        protected IStateMachine<TStateType> StateMachine { get; private set; }
        protected IPersistentData PersistentData { get; private set; }
        protected ISharedData<TStateType> SharedData { get; private set; }

        [Inject]
        protected void AddDependencies(IStateMachine<TStateType> stateMachine, IPersistentData persistentData,
            ISharedData<TStateType> sharedData)
        {
            StateMachine = stateMachine;
            PersistentData = persistentData;
            SharedData = sharedData;

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
        }

        protected virtual void PostStateUpdate()
        {
        }

        private void OnStateChanged(TStateType nextState)
        {
            SharedData.CurrentState.Value = nextState;
        }
    }
}