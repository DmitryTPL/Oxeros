using System;
using MVP;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MobPresenter : StatePresenterBase<MobState>, IFixedTickable
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Rigidbody _rigidbody;

            public Vector3 LinearVelocity => _rigidbody.linearVelocity;
            public Vector3 AngularVelocity => _rigidbody.angularVelocity;
            public Quaternion Rotation => _rigidbody.transform.rotation;

            public void ResetInertia()
            {
                _rigidbody.inertiaTensor = _rigidbody.inertiaTensor;
                _rigidbody.inertiaTensorRotation = _rigidbody.inertiaTensorRotation;
            }
        }

        private readonly IMobPerUpdateData _perUpdateData;
        private readonly MobConfig _config;
        private readonly IMoveAbility _moveAbility;
        private readonly IRotateAbility _rotateAbility;
        private Data _data;

        public MobPresenter() { }

        [Inject]
        public MobPresenter(IMobPerUpdateData perUpdateData, MobConfig config, IMoveAbility moveAbility, IRotateAbility rotateAbility,
            IHealthHandler healthHandler)
        {
            _perUpdateData = perUpdateData;
            _config = config;
            _moveAbility = moveAbility;
            _rotateAbility = rotateAbility;

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

#if UNITY_EDITOR
            _moveAbility.Init(_config.Acceleration, _config.MaxAcceleration);
            _rotateAbility.Init(_config.RotationSpeed, _config.RotationDamper);
#endif
            _perUpdateData.LinearVelocity = _data.LinearVelocity;
            _perUpdateData.AngularVelocity = _data.AngularVelocity;
            _perUpdateData.Rotation = _data.Rotation;
            _perUpdateData.Position = _data.Transform.position;
        }

        public void FixedTick()
        {
            UpdateState();
        }
    }
}