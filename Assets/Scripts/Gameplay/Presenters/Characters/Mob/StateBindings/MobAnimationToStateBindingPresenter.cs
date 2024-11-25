using System;
using MVP;
using StateBindings;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MobAnimationToStateBindingPresenter : BaseDataToStateBindingPresenter<MobState, MobAnimationToStateBinding, AnimationData<MobState, MobAnimationLayer>>
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Animator _animator;
            [SerializeField] private float _crossFadeTime;
        
            public Animator Animator => _animator;
            public float CrossFadeTime => _crossFadeTime;
        }
        
        private readonly IMobAnimationHandler _animationHandler;
        
        public MobAnimationToStateBindingPresenter()
        {
        }
        
        [Inject]
        public MobAnimationToStateBindingPresenter(IMobAnimationHandler animationHandler)
        {
            _animationHandler = animationHandler;
        }
        
        protected override void InitializeData()
        {
            base.InitializeData();
        
            var data = GetSharedData<Data>();
        
            _animationHandler.Init(States, data.Animator, data.CrossFadeTime);
        }
        
        protected override void ProcessStateData(AnimationData<MobState, MobAnimationLayer> data)
        {
            _animationHandler.StateChanged(CurrentState);
        }
        
        protected override void ProcessStateDataAbsent()
        {
            _animationHandler.StateChanged(CurrentState);
        }
    }
}