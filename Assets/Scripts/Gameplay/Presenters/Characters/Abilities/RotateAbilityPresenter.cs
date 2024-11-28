using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using Shared;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RotateAbilityPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Rigidbody _rigidbody;

            public Rigidbody Rigidbody => _rigidbody;
        }

        private Data _data;
        private readonly IRotateAbility _rotateAbility;
        private readonly IAppTime _appTime;

        public RotateAbilityPresenter() { }

        [Inject]
        public RotateAbilityPresenter(IRotateAbility rotateAbility, IAppTime appTime)
        {
            _rotateAbility = rotateAbility;
            _appTime = appTime;

            rotateAbility.Direction.WithoutCurrent().ForEachAsync(DirectionChanged).Forget();
            rotateAbility.Stop.WithoutCurrent().ForEachAsync(StopRotation).Forget();
            rotateAbility.ForceDirection.WithoutCurrent().ForEachAsync(ForceRotate).Forget();
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();
        }

        private void DirectionChanged(Vector3 direction)
        {
            var rotation = GetRotation(direction, _data.Transform.rotation, _data.Rigidbody.angularVelocity,
                _rotateAbility.Parameters.RotationSpeed, _rotateAbility.Parameters.RotationDamper);

            _data.Rigidbody.AddTorque(rotation * _data.Rigidbody.mass);
        }

        private void StopRotation(bool _)
        {
            _data.Rigidbody.angularVelocity = Vector3.zero;
        }

        private void ForceRotate(Vector3 direction)
        {
            _data.Rigidbody.angularVelocity = Vector3.zero;
            _data.Rigidbody.transform.rotation = Quaternion.LookRotation(direction);
        }

        private Vector3 GetRotation(Vector3 direction, Quaternion currentRotation, Vector3 angularVelocity, float rotationSpeed, float rotationDamper)
        {
            var rotation = Quaternion.LookRotation(direction);
            var targetRotation = Quaternion.Slerp(currentRotation, rotation, MathUtils.GetInterpolant(rotationSpeed, _appTime.FixedDeltaTime));

            MathUtils.GetShortestRotation(targetRotation, currentRotation).ToAngleAxis(out var rotationAngle, out var rotationAxis);

            return rotationAxis.normalized * rotationAngle * Mathf.Deg2Rad - (new Vector3(0, angularVelocity.y, 0) * rotationDamper);
        }
    }
}