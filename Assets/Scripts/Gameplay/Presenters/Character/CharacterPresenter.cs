using System;
using MVP;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterPresenter : StatePresenterBase<ICharacterStateResult, CharacterState>, IFixedTickable
    {
        [Serializable]
        public class Data: PresenterViewSharedData
        {
            [SerializeField] private Rigidbody _rigidbody;

            public Vector3 LinearVelocity => _rigidbody.linearVelocity;
        }
        
        private readonly ICharacterPerUpdateData _perUpdateData;
        private Data _data;

        public CharacterPresenter() { }

        [Inject]
        public CharacterPresenter(ICharacterPerUpdateData perUpdateData)
        {
            _perUpdateData = perUpdateData;
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();
        }

        protected override void PreStateUpdate()
        {
            _perUpdateData.LinearVelocity = _data.LinearVelocity;
        }

        public void FixedTick()
        {
            UpdateState();
        }
    }
}