using System;
using System.Collections.Generic;
using MVP;
using UnityEngine;

namespace StateBindings
{
    public abstract class BaseDataToStateBindingView<TPresenter, TStateType, TBinding, TData> : View<TPresenter>
        where TPresenter : BaseDataToStateBindingPresenter<TStateType, TBinding, TData>, new()
        where TStateType : Enum
        where TBinding : BaseDataToStateBinding<TData, TStateType>
    {
        [SerializeField] private List<TBinding> _states = new();

        protected override void PresenterAttached()
        {
            Presenter.InitializeStatesData(_states);
        }
    }
}