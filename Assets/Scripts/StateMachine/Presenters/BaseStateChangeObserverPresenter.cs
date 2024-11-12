using Cysharp.Threading.Tasks;
using MVP;

namespace StateMachine
{
    public abstract class BaseStateChangeObserverPresenter : Presenter
    {
        protected readonly AsyncReactiveProperty<string> _stateChanged = new(default);

        public IReadOnlyAsyncReactiveProperty<string> StateChanged => _stateChanged;
    }
}