using System;
using UnityEngine.Events;

namespace StateBindings
{
    [Serializable]
    public class BaseUnityEventToStateBinding<TStateEnum> : BaseDataToStateBinding<UnityEvent, TStateEnum>
        where TStateEnum : Enum
    {
    }
}