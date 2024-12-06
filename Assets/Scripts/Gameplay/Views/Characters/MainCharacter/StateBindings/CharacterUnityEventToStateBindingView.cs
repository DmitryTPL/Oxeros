using StateBindings;
using UnityEngine.Events;

namespace Gameplay
{
    public class CharacterUnityEventToStateBindingView :
        BaseDataToStateBindingView<CharacterUnityEventToStateBindingPresenter, CharacterState, CharacterUnityEventToStateBinding, UnityEvent>
    {
    }
}