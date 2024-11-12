using System;
using MVP;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gameplay
{
    [Serializable]
    public class InputPresenterViewSharedData : PresenterViewSharedData
    {
        [SerializeField] private InputActionReference _action;

        public InputActionReference Action => _action;
    }

    public abstract class BaseInputPresenter<TInputData> : Presenter
        where TInputData : class, IInputData
    {
        private IInputData _inputData;

        [Inject]
        public void AddDependencies(TInputData inputData)
        {
            _inputData = inputData;
        }

        protected override void InitializeData()
        {
            if (_inputData != null)
            {
                _inputData.InputAction = GetSharedData<InputPresenterViewSharedData>().Action.ToInputAction();
            }
        }
    }
}