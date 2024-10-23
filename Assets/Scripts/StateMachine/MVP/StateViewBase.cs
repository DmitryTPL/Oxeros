using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateViewBase<TPresenter, TStateResult, TStateType> : View<TPresenter>
        where TPresenter : StatePresenterBase<TStateResult, TStateType>, new()
        where TStateResult : IStateResult
        where TStateType : Enum
    {
        [SerializeField, ReadOnly] private TStateType _currentState;

        protected override void PresenterAttached()
        {
            Presenter.StateChanged.ForEachAsync(OnStateChanged, destroyCancellationToken).Forget();
            Presenter.StateResultChanged.WithoutCurrent().ForEachAsync(OnStateDataChanged, destroyCancellationToken).Forget();
        }

        private void OnStateChanged(TStateType nextState)
        {
            _currentState = nextState;
        }

        protected virtual void OnStateDataChanged(TStateResult stateResult)
        {
        }
    }
}