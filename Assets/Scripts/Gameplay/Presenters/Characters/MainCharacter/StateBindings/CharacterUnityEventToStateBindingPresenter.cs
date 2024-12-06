using StateBindings;
using UnityEngine.Events;

namespace Gameplay
{
    public class CharacterUnityEventToStateBindingPresenter : BaseDataToStateBindingPresenter<CharacterState, CharacterUnityEventToStateBinding, UnityEvent>
    {
        protected override void ProcessStateData(UnityEvent data)
        {
            data?.Invoke();
        }
    }
}