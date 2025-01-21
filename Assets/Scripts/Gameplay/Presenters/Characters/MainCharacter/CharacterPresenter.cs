using System;
using MVP;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CharacterPresenter : StatePresenterBase<CharacterState>, IFixedTickable
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Rigidbody _rigidbody;

            public Vector3 LinearVelocity => _rigidbody.linearVelocity;
            public Vector3 AngularVelocity => _rigidbody.angularVelocity;
            public Quaternion Rotation => _rigidbody.transform.rotation;
            
            
        }

        private readonly ICharacterPerUpdateData _perUpdateData;
        private Data _data;

        public CharacterPresenter() { }

        [Inject]
        public CharacterPresenter(ICharacterPerUpdateData perUpdateData, CharacterConfig config, IMoveAbility moveAbility, IRotateAbility rotateAbility,
            IHealthHandler healthHandler)
        {
            _perUpdateData = perUpdateData;

            moveAbility.Init(config.Acceleration, config.MaxAcceleration);
            rotateAbility.Init(config.RotationSpeed, config.RotationDamper);
            healthHandler.Init(config.Health);
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();
        }

        protected override void PreStateUpdate()
        {
            _perUpdateData.LinearVelocity = _data.LinearVelocity;
            _perUpdateData.AngularVelocity = _data.AngularVelocity;
            _perUpdateData.Rotation = _data.Rotation;
        }

        public void FixedTick()
        {
            UpdateState();
        }
    }
}