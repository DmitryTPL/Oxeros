using System;
using MVP;
using StateBindings;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterAnimationToStateBindingPresenter : BaseDataToStateBindingPresenter<CharacterState, CharacterAnimationToStateBinding, AnimationData<CharacterState, CharacterAnimationLayer>>
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Animator _animator;
            [SerializeField] private float _crossFadeTime;
        
            public Animator Animator => _animator;
            public float CrossFadeTime => _crossFadeTime;
        }
        
        private readonly ICharacterAnimationHandler _animationHandler;
        
        public CharacterAnimationToStateBindingPresenter()
        {
        }
        
        [Inject]
        public CharacterAnimationToStateBindingPresenter(ICharacterAnimationHandler animationHandler)
        {
            _animationHandler = animationHandler;
        }
        
        protected override void InitializeData()
        {
            base.InitializeData();
        
            var data = GetSharedData<Data>();
        
            _animationHandler.Init(States, data.Animator, data.CrossFadeTime);
        }
        
        protected override void ProcessStateData(AnimationData<CharacterState, CharacterAnimationLayer> data)
        {
            _animationHandler.StateChanged(CurrentState);
        }
        
        protected override void ProcessStateDataAbsent()
        {
            _animationHandler.StateChanged(CurrentState);
        }
    }
}