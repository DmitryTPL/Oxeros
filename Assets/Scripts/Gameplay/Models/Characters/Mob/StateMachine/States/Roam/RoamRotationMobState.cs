using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class RoamRotationMobState : BaseMobState
    {
        private readonly IRoamArea _roamArea;
        private readonly IRotateAbility _rotateAbility;
        private readonly IMobPerUpdateData _perUpdateData;
        private readonly IMobPersistentData _persistentData;
        private readonly IMoveAbility _moveAbility;

        public override MobState State => MobState.RoamRotation;

        public RoamRotationMobState(IRoamArea roamArea, IRotateAbility rotateAbility, IMobPerUpdateData perUpdateData,
            IMobPersistentData persistentData, IMoveAbility moveAbility)
        {
            _roamArea = roamArea;
            _rotateAbility = rotateAbility;
            _perUpdateData = perUpdateData;
            _persistentData = persistentData;
            _moveAbility = moveAbility;
        }

        public override async UniTask Enter()
        {
            await base.Enter();

            _rotateAbility.StopRotation();
            _moveAbility.StopMovement();
            _persistentData.RoamRotationFinished = false;

            const int pathGenerationTries = 10;

            for (var i = 0; i < pathGenerationTries; i++)
            {
                _persistentData.RoamPathDestination = _roamArea.GetPointInside();
                _persistentData.RoamPathStart = _perUpdateData.Position;

                var path = _persistentData.RoamPathDestination - _persistentData.RoamPathStart;

                _persistentData.RoamPathDirection = path.normalized;

                if (Vector3.ProjectOnPlane(path, Vector3.up).magnitude > _roamArea.MinRoamPathLength)
                {
                    break;
                }
            }
        }

        protected override async UniTask HandleControl()
        {
            await base.HandleControl();

            if (Vector3.Angle(Vector3.ProjectOnPlane(_persistentData.RoamPathDirection, Vector3.up),
                    Vector3.ProjectOnPlane(_perUpdateData.Rotation * Vector3.forward, Vector3.up)) < 3)
            {
                _persistentData.RoamRotationFinished = true;
            }

            _rotateAbility.Rotate(_persistentData.RoamPathDirection);
        }

        public override async UniTask Exit()
        {
            await base.Exit();

            _rotateAbility.StopRotation();
        }
    }
}