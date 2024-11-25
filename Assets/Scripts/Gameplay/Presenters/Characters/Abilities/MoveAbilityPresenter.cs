using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using MVP;
using Shared;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class MoveAbilityPresenter : Presenter
    {
        [Serializable]
        public class Data : PresenterViewSharedData
        {
            [SerializeField] private Rigidbody _rigidbody;

            public Rigidbody Rigidbody => _rigidbody;
        }

        private readonly ISpeedModifiersHolder _speedModifiersHolder;
        private readonly IAppTime _appTime;
        private Vector3 _goalVelocity;
        private readonly IMoveAbility _moveAbility;

        private Data _data;

        public MoveAbilityPresenter()
        {
        }

        [Inject]
        public MoveAbilityPresenter(IMoveAbility moveAbility, ISpeedModifiersHolder speedModifiersHolder, IAppTime appTime)
        {
            _speedModifiersHolder = speedModifiersHolder;
            _appTime = appTime;
            _moveAbility = moveAbility;

            moveAbility.Velocity.WithoutCurrent().ForEachAsync(VelocityChanged, DestroyCancellationToken).Forget();
            moveAbility.Stop.WithoutCurrent().ForEachAsync(Stop, DestroyCancellationToken).Forget();
        }

        protected override void InitializeData()
        {
            base.InitializeData();

            _data = GetSharedData<Data>();
        }

        private void VelocityChanged(Velocity velocity)
        {
            var acceleration = GetAcceleration(velocity, _data.Rigidbody.linearVelocity, _moveAbility.Parameters.Acceleration, _moveAbility.Parameters.MaxAcceleration);

            _data.Rigidbody.AddForce(acceleration, ForceMode.Acceleration);
        }

        private Vector3 GetAcceleration(Velocity velocity, Vector3 currentVelocity, float acceleration, float maxAcceleration)
        {
            if (velocity.Direction == Vector3.zero)
            {
                return Vector3.zero;
            }

            var moveVelocity = velocity.Value * _speedModifiersHolder.TotalValue;

            _goalVelocity = Vector3.MoveTowards(_goalVelocity, moveVelocity, acceleration * _appTime.FixedDeltaTime);

            var neededAcceleration = (_goalVelocity - currentVelocity) / _appTime.FixedDeltaTime;

            return Vector3.ClampMagnitude(Vector3.Scale(neededAcceleration, new Vector3(1, 0, 1)), maxAcceleration);
        }

        private void Stop(bool _)
        {
            _data.Rigidbody.linearVelocity = Vector3.zero;
        }
    }
}