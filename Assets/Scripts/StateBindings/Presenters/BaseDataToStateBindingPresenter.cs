using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using StateMachine;
using Zenject;

namespace StateBindings
{
    public abstract class BaseDataToStateBindingPresenter<TStateType, TBinding, TData> : Presenter
        where TStateType : Enum
        where TBinding : BaseDataToStateBinding<TData, TStateType>
    {
        protected Dictionary<TStateType, TData> States { get; } = new();

        protected TStateType CurrentState { get; private set; }

        [Inject]
        private void AddDependencies(ISharedData<TStateType> sharedData)
        {
            sharedData.CurrentState.WithoutCurrent().ForEachAsync(StateChanged, DestroyCancellationToken);
        }

        public void InitializeStatesData(List<TBinding> statesBindings)
        {
            foreach (var binding in statesBindings)
            {
                States[binding.State] = binding.Data;
            }
        }

        private void StateChanged(TStateType changedToState)
        {
            if (DestroyCancellationToken.IsCancellationRequested)
            {
                return;
            }

            CurrentState = changedToState;

            if (!States.TryGetValue(changedToState, out var data))
            {
                ProcessStateDataAbsent();
            }
            else
            {
                ProcessStateData(data);
            }
        }

        protected abstract void ProcessStateData(TData data);

        protected virtual void ProcessStateDataAbsent()
        {
        }
    }
}