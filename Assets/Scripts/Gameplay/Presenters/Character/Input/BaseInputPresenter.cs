using System;
using MVP;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public abstract class BaseInputPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private InputActionReference _action;

            public InputActionReference Action => _action;
        }

        private readonly IInputData _inputData;

        protected BaseInputPresenter(IInputData inputData)
        {
            _inputData = inputData;
        }

        protected override void InitializeData()
        {
            if (_inputData != null)
            {
                _inputData.InputAction = GetSharedData<Data>().Action.ToInputAction();
            }
        }
    }
}