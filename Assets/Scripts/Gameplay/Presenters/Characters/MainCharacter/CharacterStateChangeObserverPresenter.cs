using StateMachine;
using Cysharp.Threading.Tasks.Linq;
using Zenject;

namespace Gameplay
{
    public class CharacterStateChangeObserverPresenter : BaseStateChangeObserverPresenter
    {
        public CharacterStateChangeObserverPresenter() { }
        
        [Inject]
        public CharacterStateChangeObserverPresenter(ICharacterSharedData sharedData)
        {
            sharedData.CurrentState.WithoutCurrent().ForEachAsync(s => _stateChanged.Value = s.ToString());
        }
    }
}