using System;
using MVP;
using StateBindings;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterAnimationToStateBindingPresenter : BaseDataToStateBindingPresenter<CharacterState, CharacterAnimationToStateBinding, AnimationData<CharacterState, CharacterAnimationLayer>>,
        ITickable
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Animator _animator;
            [SerializeField] private float _crossFadeTime;
        
            public Animator Animator => _animator;
            public float CrossFadeTime => _crossFadeTime;
        }
        
        private static readonly int _speedFactorAnimatorParameter = Animator.StringToHash("SpeedFactor");
        
        private readonly ICharacterAnimationHandler _animationHandler;
        private readonly ISpeedModifiersHolder _speedModifiers;
        private Data _data;

        public CharacterAnimationToStateBindingPresenter()
        {
        }
        
        [Inject]
        public CharacterAnimationToStateBindingPresenter(ICharacterAnimationHandler animationHandler, ISpeedModifiersHolder speedModifiers)
        {
            _animationHandler = animationHandler;
            _speedModifiers = speedModifiers;
        }
        
        protected override void InitializeData()
        {
            base.InitializeData();
        
            _data = GetSharedData<Data>();
        
            _animationHandler.Init(States, _data.Animator, _data.CrossFadeTime);
        }
        
        protected override void ProcessStateData(AnimationData<CharacterState, CharacterAnimationLayer> data)
        {
            _animationHandler.StateChanged(CurrentState);
        }
        
        protected override void ProcessStateDataAbsent()
        {
            _animationHandler.StateChanged(CurrentState);
        }

        public void Tick()
        {
            if (_data == null)
            {
                return;
            }
            
            _data.Animator.SetFloat(_speedFactorAnimatorParameter, 1f);
        }
    }
}