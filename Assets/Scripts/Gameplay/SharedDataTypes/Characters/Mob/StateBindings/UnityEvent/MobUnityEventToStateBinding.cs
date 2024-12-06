using System;
using StateBindings;
using UnityEngine.Events;

namespace Gameplay
{
    [Serializable]
    public class MobUnityEventToStateBinding : BaseDataToStateBinding<UnityEvent, MobState>
    {
    }
}