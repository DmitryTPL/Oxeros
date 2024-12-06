using System;
using StateBindings;
using UnityEngine.Events;

namespace Gameplay
{
    [Serializable]
    public class CharacterUnityEventToStateBinding : BaseDataToStateBinding<UnityEvent, CharacterState>
    {
    }
}