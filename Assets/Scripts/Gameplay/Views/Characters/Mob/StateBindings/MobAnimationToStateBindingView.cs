using MVP;
using StateBindings;
using UnityEngine;

namespace Gameplay
{
    public class MobAnimationToStateBindingView : BaseDataToStateBindingView<MobAnimationToStateBindingPresenter, MobState, MobAnimationToStateBinding, AnimationData<MobState, MobAnimationLayer>>
    {
        [SerializeField] private MobAnimationToStateBindingPresenter.Data _data;
        
        protected override PresenterViewSharedData SharedData => _data;
    }
}