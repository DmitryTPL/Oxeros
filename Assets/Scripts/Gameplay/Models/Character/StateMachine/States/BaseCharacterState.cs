using System.Linq;
using Cysharp.Threading.Tasks;
using Data;
using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public abstract class BaseCharacterState : BaseStateWithTransitions<CharacterState, CharacterTransition, ICharacterTransition, ICharacterTransitionsHolder,
        ICharacterStateTimingHandler, CharacterStateTimeConfig, CharacterStateToTimeDictionary>, ICharacterState
    {
        private IMoveInputData _moveInputData;

        private IGravityForceReaction _gravityForceReaction;
        private IRotateReaction _rotateReaction;
        private IMoveReaction _moveReaction;
        private ISpeedModifiersHolder _speedModifiersHolder;

        protected CharacterConfig Config { get; private set; }
        protected ICharacterPersistentData PersistentData { get; private set; }
        protected ICharacterPerUpdateData PerUpdateData { get; private set; }
        protected IAppTime AppTime { get; private set; }

        protected virtual bool IsRotationPaused => _moveInputData.Value.magnitude <= float.Epsilon;

        protected virtual Vector3 MoveDirection => _moveInputData.Value.normalized;

        [Inject]
        public void AddDependencies(CharacterConfig config, ICharacterPersistentData persistentData, ICharacterPerUpdateData perUpdateData,
            IMoveInputData moveInputData, IAppTime appTime, IGravityForceReaction gravityForceReaction, IRotateReaction rotateReaction,
            IMoveReaction moveReaction, ISpeedModifiersHolder speedModifiersHolder)
        {
            _moveInputData = moveInputData;

            _gravityForceReaction = gravityForceReaction;
            _rotateReaction = rotateReaction;
            _moveReaction = moveReaction;
            _speedModifiersHolder = speedModifiersHolder;

            Config = config;
            PersistentData = persistentData;
            PerUpdateData = perUpdateData;
            AppTime = appTime;
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            ApplyGravitationForce();
            ApplyRotation();
        }

        private void ApplyRotation()
        {
            if (IsRotationPaused)
            {
                _rotateReaction.Rotation.Value = Vector3.zero;
                _rotateReaction.Stop.Value = true;

                return;
            }

            var rotation = Quaternion.LookRotation(MoveDirection);
            var targetRotation = Quaternion.Slerp(PerUpdateData.Rotation, rotation, AppTime.FixedDeltaTime * Config.RotationSpeed);

            (Quaternion.Dot(targetRotation, PerUpdateData.Rotation) < 0
                    ? targetRotation * Quaternion.Inverse(Multiply(PerUpdateData.Rotation, -1))
                    : targetRotation * Quaternion.Inverse(PerUpdateData.Rotation))
                .ToAngleAxis(out var rotationAngle, out var rotationAxis);

            rotationAxis.Normalize();

            _rotateReaction.Rotation.Value = rotationAxis * rotationAngle * Mathf.Deg2Rad - (PerUpdateData.AngularVelocity * Config.RotationDamper);
        }

        protected virtual void ApplyGravitationForce()
        {
            _gravityForceReaction.GravityForce.Value = Physics.gravity * Config.GravitationFactor;
        }

        protected void ApplyMove(Vector3 moveVelocity)
        {
            if (moveVelocity.magnitude < float.Epsilon)
            {
                return;
            }

            moveVelocity *= _speedModifiersHolder.TotalValue;

            PersistentData.GoalVelocity = Vector3.MoveTowards(PersistentData.GoalVelocity, moveVelocity, Config.Acceleration * AppTime.FixedDeltaTime);

            var neededAcceleration = (PersistentData.GoalVelocity - PerUpdateData.LinearVelocity) / AppTime.FixedDeltaTime;

            _moveReaction.Acceleration.Value = Vector3.ClampMagnitude(Vector3.Scale(neededAcceleration, new Vector3(1, 0, 1)), Config.MaxAcceleration);
        }

        private static Quaternion Multiply(Quaternion quaternion, float scalar)
        {
            return new Quaternion(quaternion.x * scalar, quaternion.y * scalar, quaternion.z * scalar, quaternion.w * scalar);
        }
    }
}