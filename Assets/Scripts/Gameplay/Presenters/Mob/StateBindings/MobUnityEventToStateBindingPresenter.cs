using StateBindings;
using UnityEngine.Events;

namespace Gameplay
{
    public class MobUnityEventToStateBindingPresenter : BaseDataToStateBindingPresenter<MobState, MobUnityEventToStateBinding, UnityEvent>
    {
        protected override void ProcessStateData(UnityEvent data)
        {
            data?.Invoke();
        }
    }
}