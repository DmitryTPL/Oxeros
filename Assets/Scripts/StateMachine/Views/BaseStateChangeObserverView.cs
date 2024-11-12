using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseStateChangeObserverView<TPresenter> : View<TPresenter>
        where TPresenter : BaseStateChangeObserverPresenter, new()
    {
        [SerializeField, ReadOnly] private string _currentState;

        protected override void PresenterAttached()
        {
            Presenter.StateChanged.ForEachAsync(OnStateChanged, destroyCancellationToken).Forget();
        }

        private void OnStateChanged(string nextState)
        {
            _currentState = nextState;
        }
    }
}