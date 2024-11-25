using MVP;
using StateBindings;
using UnityEngine;

namespace Gameplay
{
    public class CharacterAnimationToStateBindingView : BaseDataToStateBindingView<CharacterAnimationToStateBindingPresenter, CharacterState, CharacterAnimationToStateBinding, AnimationData<CharacterState, CharacterAnimationLayer>>
    {
        [SerializeField] private CharacterAnimationToStateBindingPresenter.Data _data;
        
        protected override PresenterViewSharedData SharedData => _data;
    }
}