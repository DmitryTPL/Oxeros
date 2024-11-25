using StateMachine;
using Cysharp.Threading.Tasks.Linq;
using Zenject;

namespace Gameplay
{
    public class MobStateChangeObserverPresenter : BaseStateChangeObserverPresenter
    {
        public MobStateChangeObserverPresenter() { }
        
        [Inject]
        public MobStateChangeObserverPresenter(IMobSharedData sharedData)
        {
            sharedData.CurrentState.WithoutCurrent().ForEachAsync(s => _stateChanged.Value = s.ToString());
        }
    }
}